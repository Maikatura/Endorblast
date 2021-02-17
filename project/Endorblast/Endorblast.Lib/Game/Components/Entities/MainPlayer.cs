
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
using Endorblast.Lib.Components;
using Endorblast.Lib.Skills;
using Nez.Tiled;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Network;
using Endorblast.Lib.Game.Player;
using Endorblast.Lib.Game.Network;
using Endorblast.Lib.GameObjects;
using Endorblast.Lib.GUI;
using Nez.DeferredLighting;

namespace Endorblast.Lib.Entities
{
    public class MainPlayer : BasePlayer, IUpdatable
    {


        //bool IsMoving => Key.MoveLeft || Key.MoveRight;


        float SendPositionTimer;
        //float activityTimer = 0;


        FollowCamera camera;
        ParallaxBackgroundComp parallax;


        int lastBytesSent = 0;
        int lastBytesReceived = 0;
        float time = 0;

        DirLight dirLight;
        
        List<Collider> cacheColliders = new List<Collider>();
        

        public override void OnAddedToEntity()
        {
            base.InitComponents();

           
            

            camera = this.GetComponent<FollowCamera>();
            camera.Follow(this.Entity, FollowCamera.CameraStyle.LockOn);
            camera.Transform.Position = Entity.Transform.Position;

            parallax = Entity.AddComponent(new ParallaxBackgroundComp(new List<ParallaxBGSprite>()
            {
                new ParallaxBGSprite("/Sprites/Enviorment/Backgrounds/Forest/cloud.png", 0.1f),
                new ParallaxBGSprite("/Sprites/Enviorment/Backgrounds/Forest/mountain2.png", 0.5f),
                new ParallaxBGSprite("/Sprites/Enviorment/Backgrounds/Forest/sky.png", 0.9f)
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

            if (Input.IsKeyPressed(Keys.C))
            {
                GearUI.Instance.OpenAndClose();
            }

            camera.Camera.Transform.Position = this.Entity.Transform.Position;

            SendPositionTimer += Time.DeltaTime;
            if (SendPositionTimer > 0.015f)
            {
                if (OldMoveState != moveState)
                {
                    new CharacterSendInputCommand().Send(moveState); // need how monogame do deltatime
                    SendPositionTimer = 0;
                }

                OldMoveState = moveState;
            }
            
            var neighborColliders = Physics.BoxcastBroadphaseExcludingSelf(boxCollider);

            // loop through and check each Collider for an overlap
            foreach (var collider in neighborColliders)
            {
                if (!cacheColliders.Contains(collider) && boxCollider.Overlaps(collider))
                {
                    cacheColliders.Add(collider);
                }

                if (cacheColliders.Contains(collider) && !boxCollider.Overlaps(collider))
                {
                    cacheColliders.Remove(collider);
                }
            }
            
            foreach (var item in cacheColliders)
            {
                if (boxCollider.Overlaps(item))
                {
                    if (item.HasComponent<PortalScript>())
                    {
                        var script = item.GetComponent<PortalScript>();
                        if (!script.InitedText)
                        {
                            script.EnterText();
                        }
                    }
                }

                if (!boxCollider.Overlaps(item))
                {
                    if (item.HasComponent<PortalScript>())
                    {
                        var script = item.GetComponent<PortalScript>();
                        if (script.InitedText)
                        {
                            script.ExitText();
                        }
                    }
                }
                
                
            }


#if DEBUG
            //if (Nez.Core.Instance.Window != null && NetworkManager.Instance.client != null && time <= 0)
            //{
            //    //new SendPingCommand().Send(Time.TotalTime);

            //    Nez.Core.Instance.Window.Title =
            //        $"Endorblast - " +
            //        $"[Ping: {NetworkManager.Instance.ping}" +
            //        $"[Recived: {(NetworkManager.Instance.client.Statistics.ReceivedBytes - lastBytesReceived)} b/s] " +
            //        $"[Sent: {(NetworkManager.Instance.client.Statistics.SentBytes - lastBytesSent)} b/s]";
            //    lastBytesReceived = NetworkManager.Instance.client.Statistics.ReceivedBytes;
            //    lastBytesSent = NetworkManager.Instance.client.Statistics.SentBytes;
            //    time = 1;
            //}
            //else
            //{
            //    time -= Time.DeltaTime;
            //}
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
                        DoSkill(SkillType.HeavyAttack, this, rotation);
                    }

                    if (Input.IsKeyDown(Keys.D2))
                    {
                        DoSkill(SkillType.Dash, this, rotation);
                    }

                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        DoSkill(SkillType.Basic, this, rotation);
                    }
                }           
            }
        }
        
        

    }
}
