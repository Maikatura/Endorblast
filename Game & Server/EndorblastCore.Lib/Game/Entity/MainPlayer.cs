
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib;
using EndorblastCore.Lib.Skills;
using Nez.Tiled;
using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib.Network;
using EndorblastCore.Lib.Game.Player;
using EndorblastCore.Lib.Game.Network;
using EndorblastCore.Lib.GUI;

namespace EndorblastCore.Lib
{
    public class MainPlayer : BasePlayer, IUpdatable
    {


        //bool IsMoving => Key.MoveLeft || Key.MoveRight;


        float SendPositionTimer;
        //float activityTimer = 0;


        FollowCamera camera;
        ParallaxBackground parallax;


        int lastBytesSent = 0;
        int lastBytesReceived = 0;
        float time = 0;


        public override void OnAddedToEntity()
        {
            base.InitComponents();

            camera = this.GetComponent<FollowCamera>();
            camera.Follow(this.Entity, FollowCamera.CameraStyle.LockOn);

            parallax = Entity.AddComponent(new ParallaxBackground(new List<ParallaxBGSprite>()
            {
                new ParallaxBGSprite("/Enviorment/Backgrounds/Forest/cloud.png", 0.1f),
                new ParallaxBGSprite("/Enviorment/Backgrounds/Forest/mountain2.png", 0.5f),
                new ParallaxBGSprite("/Enviorment/Backgrounds/Forest/sky.png", 0.9f)
            }));

            currentSkill = new Skill();

            isMainPlayer = true;
        }



        public override void Update()
        {
            base.Update();

            SkillInputs();

            if (Input.IsKeyPressed(Keys.I))
            {
                InventoryUI.Instance.OpenAndCloseInv();
            }

            camera.Camera.Transform.Position = this.Entity.Transform.Position;

            SendPositionTimer += Time.DeltaTime;
            if (SendPositionTimer > 0.015f)
            {
                if (OldMoveState != moveState)
                {
                    new CharacterSendInputCommand().Send(moveState);
                    SendPositionTimer = 0;
                }

                OldMoveState = moveState;
            }




#if DEBUG
            if (Nez.Core.Instance.Window != null && NetworkManager.Instance.client != null && time <= 0)
            {
                //new SendPingCommand().Send(Time.TotalTime);

                Nez.Core.Instance.Window.Title =
                    $"Endorblast - " +
                    $"[Ping: {NetworkManager.Instance.ping}" +
                    $"[Recived: {(NetworkManager.Instance.client.Statistics.ReceivedBytes - lastBytesReceived)} b/s] " +
                    $"[Sent: {(NetworkManager.Instance.client.Statistics.SentBytes - lastBytesSent)} b/s]";
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


        public void MovementPrediction()
        {

        }


        void SkillInputs()
        {
            if (currentSkill != null)
            {
                if (currentSkill.isExiting)
                {
                    var dir = Vector2.Normalize(Input.MousePosition);
                    var rotation = Mathf.Degrees((float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f));

                    if (Input.IsKeyDown(Keys.D1))
                    {
                        DoSkill(SkillType.Dash, this, rotation);
                        new CharacterSkillCastCommand().Send(SkillType.Dash, rotation);
                    }

                    if (Input.IsKeyDown(Keys.Space))
                    {
                        DoSkill(SkillType.Jump, this, rotation);
                        new CharacterSkillCastCommand().Send(SkillType.Jump, rotation);
                    }

                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        DoSkill(SkillType.Basic, this, rotation);
                        new CharacterSkillCastCommand().Send(SkillType.Basic, rotation);
                    }
                }


                
            }
        }

    }


}
