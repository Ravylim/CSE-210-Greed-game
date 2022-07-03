using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;


namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        public int value = 0;
        // private int dx = 0;
        // private int dy = 1;
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;


        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;

        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {

            // Artifact artifacts = new Artifact();
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Artifact artifact = new Artifact();
            List <Actor> artifacts = cast.GetActors("artifacts");
            foreach (Actor actor in artifacts)
            {
                Point artVelocity = artifact.MoveArtifact();
                actor.SetVelocity(artVelocity);
                int maxX = videoService.GetWidth();
                int maxY = videoService.GetHeight();
                actor.MoveNext(maxX,maxY);
            }
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            robot.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Random random = new Random();
            List<Actor> artifacts = cast.GetActors("artifacts");
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            // // List<Actor> artifact = cast.GetActors("artifacts");
            // Point velocity = new Point(0, 1);
            // Artifact artifact = new Artifact();
            // artifact.GetVelocity();
            // artifact.SetVelocity(velocity);

            banner.SetText($"Value: {value.ToString()}");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Actor actor in artifacts)
            {

                // maxX = videoService.GetWidth();
                // maxY = videoService.GetHeight();
                // actor.MoveNext(maxX, maxY);
                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    Artifact artifactt = (Artifact)actor;
                    
                    value += artifactt.GetValue();
                    banner.SetText($"Value: {value.ToString()}");

                    int x = random.Next(1,60);
                    int y = 1;
                    Point position = new Point(x,y);
                    position = position.Scale(15);

                    artifactt.SetPosition(position);
                }
            }
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}