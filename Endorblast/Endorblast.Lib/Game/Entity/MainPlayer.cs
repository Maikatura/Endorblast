
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;
using Endorblast.Lib.Skills;
using Nez.Tiled;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Network;
using Endorblast.Lib.Game.Player;
using Endorblast.Lib.Game.Network;

namespace Endorblast.Lib
{
    public class MainPlayer : BasePlayer, IUpdatable
    {


        bool IsMoving => Key.MoveLeft || Key.MoveRight;

        bool OldPosIsPos =>
            Transform.Position.X == OldPosition.X &&
            Transform.Position.Y == OldPosition.Y;

        float SendPositionTimer;
        float activityTimer = 0;
        Vector2 mouseInput;

        FollowCamera camera;
        ParallaxBackground parallax;


        int lastBytesSent = 0;
        int lastBytesReceived = 0;
        float time = 0;


        public override void OnAddedToEntity()
        {
            Key = this.GetComponent<KeyboardInput>();
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();
            camera = this.GetComponent<FollowCamera>();
            camera.Follow(this.Entity, FollowCamera.CameraStyle.LockOn);

            animations = Entity.AddComponent(new PlayerAnimations());
            animations.LoadSet(2);
            animations.LoadHair(1);

            parallax = Entity.AddComponent(new ParallaxBackground(new List<ParallaxBGSprite>()
            {
                new ParallaxBGSprite("/Enviorment/Backgrounds/Forest/cloud.png", 0.1f),
                new ParallaxBGSprite("/Enviorment/Backgrounds/Forest/mountain2.png", 0.5f),
                new ParallaxBGSprite("/Enviorment/Backgrounds/Forest/sky.png", 0.9f)
            }));

            isMainPlayer = true;
        }



        public override void Update()
        {
            base.Update();

            SendPositionTimer += Time.DeltaTime;
            if (SendPositionTimer > 0.1f)
            {
                new CharacterSendInputCommand().Send(moveState, DateTime.Now.Ticks);
                SendPositionTimer = 0;
            }
               
            

            if (Input.IsKeyDown(Keys.D1))
            {
                mouseInput = Input.MousePosition;
                var dir = Vector2.Normalize(Input.MousePosition);
                var rotation = Mathf.Degrees((float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f));

                DoSkill(SkillType.Dash, this, rotation);
                new CharacterSkillCastCommand().Send(SkillType.Dash, rotation);
            }

            

            if (Input.IsKeyDown(Keys.Space) && collisionState.Below){
                mouseInput = Input.MousePosition;
                var dir = Vector2.Normalize(Input.MousePosition);
                var rotation = Mathf.Degrees((float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f));

                DoSkill(SkillType.Jump, this, rotation);
                new CharacterSkillCastCommand().Send(SkillType.Jump, rotation);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mouseInput = Input.MousePosition;
                var dir = Vector2.Normalize(Input.MousePosition);
                var rotation = Mathf.Degrees((float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f));

                DoSkill(SkillType.Basic, this, rotation);
                new CharacterSkillCastCommand().Send(SkillType.Basic, rotation);
            }


            

            camera.Camera.Transform.Position = this.Entity.Transform.Position;
            //parallax.bgObject.Transform.Position = this.Entity.Transform.Position;

            activityTimer += Time.DeltaTime;
            if (activityTimer > 1)
            {
                
                
                
                activityTimer = 0;
            }

#if DEBUG
            if (Nez.Core.Instance.Window != null && NetworkManager.Instance.client != null && time <= 0)
            {
                //new SendPingCommand().Send(Time.TotalTime);

                Nez.Core.Instance.Window.Title =
                    $"Endorblast - " +
                    $"[Ping: {NetworkManager.Instance.ping}" +
                    $"[Recived: {(NetworkManager.Instance.client.Statistics.ReceivedBytes - lastBytesReceived).ToString()} b/s] " +
                    $"[Sent: {(NetworkManager.Instance.client.Statistics.SentBytes - lastBytesSent).ToString()} b/s]";
                lastBytesReceived = NetworkManager.Instance.client.Statistics.ReceivedBytes;
                lastBytesSent = NetworkManager.Instance.client.Statistics.SentBytes;
                time = 1;
            }
            else
            {
                time -= Time.DeltaTime;
            }
#endif
        }



    }

    
}
