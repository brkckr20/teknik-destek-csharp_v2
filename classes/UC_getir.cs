using System.Windows.Controls;

namespace ExtremeTaleplerV2.classes
{
    public class UC_getir
    {
        public static void UC_Ekle(Grid grd, UserControl uc)
        {
            if (grd.Children.Count>0)
            {
                grd.Children.Clear();
                grd.Children.Add(uc);
            }
            else
            {
                grd.Children.Add(uc);
            }
        }
    }
}
