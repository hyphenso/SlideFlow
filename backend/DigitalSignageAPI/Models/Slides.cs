public class Slide
{
    public int SlideId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Html { get; set; } = string.Empty;

    public DateTime? ScheduleStart { get; set; }
    public DateTime? ScheduleEnd { get; set; }
}
