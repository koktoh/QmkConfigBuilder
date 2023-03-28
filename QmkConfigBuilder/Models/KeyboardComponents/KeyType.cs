using System.ComponentModel.DataAnnotations;

namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public enum KeyType
    {
        Normal,
        [Display(Description = "ISO Enter")]
        ISOEnter,
        [Display(Description = "Big Ass Enter")]
        BigAssEnter,
        Encoder,
    }
}
