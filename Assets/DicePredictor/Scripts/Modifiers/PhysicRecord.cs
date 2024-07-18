using System.Collections.Generic;

public class PhysicRecord
{
    public List<PhysicFrame> Frames { get => _frames; }

    private List<PhysicFrame> _frames = new List<PhysicFrame>();

    public void AddFrame(PhysicFrame frame)
    {
        Frames.Add(frame);
    }
}