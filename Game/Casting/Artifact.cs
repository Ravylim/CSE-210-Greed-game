namespace Unit04.Game.Casting
{
    /// <summary>
    /// <para>An item of cultural or historical interest.</para>
    /// <para>
    /// The responsibility of an Artifact is to provide a message about itself.
    /// </para>
    /// </summary>
    public class Artifact : Actor
    {
        private int value = 0;
        private int cellSize = 15;

        /// <summary>
        /// Constructs a new instance of an Artifact.
        /// </summary>
        public Artifact()
        {
            // Random random = new Random();
            // int dx = 0;
            // int dy = random.Next(1, 3);

            // Point direction = new Point(dx, dy);
            // direction = direction.Scale(cellSize);
            // this.SetVelocity(direction);
        }

        /// <summary>
        /// Gets the artifact's message.
        /// </summary>
        /// <returns>The message.</returns>
        public int GetValue()
        {
            return value;
        }

        /// <summary>
        /// Sets the artifact's message to the given value.
        /// </summary>
        /// <param name="message">The given message.</param>
        public void SetValue(int value)
        {
            this.value = value;
        }

        public Point MoveArtifact()
        {
            int dx = 0;
            int dy = 1;
            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
    }
}