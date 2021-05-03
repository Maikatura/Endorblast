using Nez.Textures;

namespace Nez.Sprites
{
	public class SpriteAnimation
	{
		public readonly Sprite[] Sprites;
		public readonly float FrameRate;

		public SpriteAnimation(Sprite[] sprites, float frameRate)
		{
			Sprites = sprites;
			FrameRate = frameRate;
		}
		
		
		public SpriteAnimation(string path, int width, int height, float frameRate)
		{
			var texture = Core.Content.LoadTexture(path);
			Sprites = Sprite.SpritesFromAtlas(texture, width, height).ToArray();
			FrameRate = frameRate;
		}
	}
}
