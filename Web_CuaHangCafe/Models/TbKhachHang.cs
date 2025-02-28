using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_CuaHangCafe.Models;

public partial class TbKhachHang
{
    public Guid Id { get; set; }

    public string TenKhachHang { get; set; } = null!;
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [StringLength(10, ErrorMessage = "Số điện thoại không được quá 10 ký tự")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Số điện thoại chỉ được nhập số")]
    public string SdtkhachHang { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public virtual ICollection<TbHoaDonBan> TbHoaDonBans { get; set; } = new List<TbHoaDonBan>();
}
