using System.ComponentModel.DataAnnotations;

namespace MapsAndToolsUI.Models;

public class CallTypeModel
{
    public enum CallType
    {
        [Display(Name = "Damaged Product")]
        DamagedProduct,

        [Display(Name = "Missing Product")]
        MissingProduct,

        [Display(Name = "Order Status")]
        OrderStatus,

        [Display(Name = "Order Changes")]
        OrderChanges
    }
}
