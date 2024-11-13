using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace snack_spot.Models;

[Table("Lanche")]
public class Lanche
{
    [Key]
    public int LancheId { get; set; }
    
    [Required(ErrorMessage ="O nome do lanche deve ser informado")]
    [Display(Name ="Nome do Lanche")]
    [StringLength(80, MinimumLength =10, ErrorMessage ="O {0} deve ter no mínimo {1} e no máximo {2}")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage ="A descrição curta do lanche deve ser informado")]
    [Display(Name ="Descrição Curta do Lanche")]
    [MinLength(20, ErrorMessage ="Descrição Curta deve ter no mínimo {1} caracteres")]
    [MaxLength(50, ErrorMessage ="Descrição Curta deve ter no máximo {1} caracteres")]
    public string DescricaoCurta { get; set; }
    
    [Required(ErrorMessage ="A descrição detalhada do lanche deve ser informado")]
    [Display(Name ="Descrição Detalhada do Lanche")]
    [MinLength(40, ErrorMessage ="Descrição Detalhada deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage ="Descrição Detalhada deve ter no máximo {1} caracteres")]
    public string DescricaoDetalhada { get; set; }
    
    [Required(ErrorMessage ="Informe o preço do lanche")]
    [Display(Name ="Preço")]
    [Range(1,999.99, ErrorMessage ="O preço deve estar entre 1 e 999,99")]
    public decimal Preco { get; set; }
    
    [Display(Name ="Caminho da Imagem Normal")]
    [StringLength(250, ErrorMessage ="O caminho informado é muito grande")]
    public string ImageUrl { get; set; }
    
    [Display(Name ="Caminho da Imagem Thumbnail")]
    [StringLength(250, ErrorMessage ="O caminho informado é muito grande")]
    public string ThumbnailUrl { get; set; }
    
    [Display(Name ="Preferido?")]
    public bool IsLanchePreferido { get; set; }
    
    [Display(Name ="Em Estoque?")]
    public bool EmEstoque { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}