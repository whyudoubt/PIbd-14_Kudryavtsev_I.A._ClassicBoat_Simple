using System.Collections.Generic;

namespace ClassicBoat.MovementStrategy;

// Фабрика по созданию экземпляра BaseTemplateMovement
public static class TemplateMovementFactory
{
    private static readonly Dictionary<string, BaseTemplateMovement> _templates = new()
    {
        { "К центру", new MoveToCenter() },
        { "В правый нижний угол", new MoveToRightDownBorder() }
    };

    public static string[] Values => [.. _templates.Keys];

    public static BaseTemplateMovement? CreateTemplateMovement(string value)
    {
        _templates.TryGetValue(value, out BaseTemplateMovement? template);
        return template;
    }
}