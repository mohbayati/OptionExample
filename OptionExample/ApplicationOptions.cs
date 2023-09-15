using System.ComponentModel.DataAnnotations;

namespace OptionExample;

public class ApplicationOptions
{
    [Required]
    public string ExampleValue { get; set; } = string.Empty;
}
