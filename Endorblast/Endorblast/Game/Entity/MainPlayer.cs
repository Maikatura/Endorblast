using Endorblast.Game.Network.Commands;
using Endorblast.GamePlay.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Game.Skills;

namespace Endorblast
{
    public class MainPlayer : BasePlayer, IUpdatable
    {

        public KeyboardInput Key;
        bool IsMoving => Key.MoveLeft || Key.MoveRight;

        bool OldPosIsPos =>
            Transform.Position.X == OldPosition.X &&
            Transform.Position.Y == OldPosition.Y;

        float SendPositionTimer;
        float activityTimer;
        Vector2 mouseInput;
        

        public MainPlayer()
        {
            Key = new KeyboardInput();
            
        }

        public override void Update()
        {
            base.Update();

            SendPositionTimer += Time.DeltaTime;
            KeyInput();
            Transform.Position += direction * Speed * Time.DeltaTime;

            activityTimer += Time.DeltaTime;
            if (activityTimer > 3)
            {
                //CharacterActivityCommand().Send();
                activityTimer = 0;
            }

            
        }

        

        

        void KeyInput()
        {
            direction = Vector2.Zero;

            if (Key.MoveLeft)
                direction = new Vector2(-1, 0);

            if (Key.MoveRight)
                direction = new Vector2(1, 0);

            if (Key.MoveRight && Key.MoveLeft)
                direction = new Vector2(0, 0);

            if (Input.IsKeyDown(Keys.D1))
            {
                var test = new Vector2();


                mouseInput = Input.MousePosition;

                var dir = Vector2.Normalize(Input.MousePosition);
                var rotation = Mathf.Degrees((float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f));

                DoSkill(SkillType.Dash, this, rotation);
                
                //CharacterSkillCastCommand.Send(SkillType.Dash, rotation);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                var test = new Vector2();


                mouseInput = Input.MousePosition;

                var dir = Vector2.Normalize(Input.MousePosition);
                var rotation = Mathf.Degrees((float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f));

                DoSkill(SkillType.Basic, this, rotation);
                //CharacterSkillCastCommand.Send(SkillType.Dash, rotation);
            }


            if (IsMoving)
            {
                // LOL
            }

            if (!OldPosIsPos)
            {
                if (SendPositionTimer > 0.015)
                {
                    CharacterDataCommand.Send(CharacterDataType.Position, (int)Transform.Position.X, (int)Transform.Position.Y);
                    SendPositionTimer = 0;
                }
            }

            latestDirection = direction;
            OldPosition = Transform.Position;

        }


    }
}
