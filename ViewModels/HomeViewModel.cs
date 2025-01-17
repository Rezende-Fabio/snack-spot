
using snack_spot.Models;

namespace snack_spot.ViewModels;

class HomeViewModel
{
    public IEnumerable<Lanche> LanchesPreferidos { get; set; }
}