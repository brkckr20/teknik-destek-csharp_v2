   M S B A M L   `   `   `  ����L  HExtremeTaleplerV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ExtremeTaleplerV2ExtremeTaleplerV2  5   	   "    ExtremeTaleplerV2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ExtremeTaleplerV2     5   	   -   5          � Title$  Extreme Talepler V2.0��5   	   $	��450��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.    � AllowsTransparency$
 True��5
   	    � ShowInTaskbar$
 True��6#    � WindowState$ 	Maximized=�5   =   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �� $��0��6   ���#ececec$��	0,0,0,0.5q�63   
�������._�5      �� $��0,0,10,0q�6   .+�5      �� -   5         ��Name$ closeApp��5      $��40��6B   $��40��6N    �� Right$ 0��6Y   
������ $��0q�6�   $��	UltraBold"�6�   .��6�   X6�   �� 5      $��40��6   $��Center=�6$   $��Extreme Talepler V2.0��6F   $��10,0,0,0q�6f   6z   5      5      �� 5   
   $��1��6   ._�5      � 	 � ColumnDefinitions	 5      �� 5      $	��250 �6'   �� 5      .+�5      �� $��0��6   ���#2c2c54$��1,0,1,0q�6>   
���   �._�5      �� .+�5      �� $��Talep İşlemleri��6!   $��30��6;   $��0,3,0,2q�6G   
����������#2c2c54$��DemiBold"�6�   �� 5       $��Kullanıcı Kartları��6!   $��30��6>   $��0,0,0,10q�6J   
����������#2c2c54$��DemiBold"�6�   �� 5!      $��Arama��6    $��0,0,0,3q�60   
�������$��18(�6T   $
��Bold"�6b   
�������$��0,1,0,1q�6�   �� 5"      $��0,0,0,3q�6!   ._�5#      ]� .+�5$   "   �� $��Başlık��6(   
�������$��57��6L   6Y   �� 5%   "   -   5        
 ��Name$
 baslik��5%   *   $	��190��6[   5&      5'      �� 5(      ._�5)      ]� .+�5*   "   �� $��
Açıklama��6(   
�������6P   �� 5+   "   -   5        $
 aciklama��5+   *   6<   5,      5-      5.      5/      �� 50      $��1��6   ._�51      &   System.Windows.Controls.DataGrid  -   5          Name$ grdIslemler��51   g      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns$ False��6|      	RowHeight$ 24Q�6�    � ContextMenu 52      �� 53      $��LeftToRight=�6*   $	��200��6F    � DataContext 6R   �� *PlacementTarget.DataContext+ �� RelativeSource �� *Self+.@�54   "   m� -   5        
 � Tag$ Tümü��54   I   $��Tümü��6T   6d   m� 55   "   -   5        $ Bekleyenler��55   I   $��Bekleyenler��6[   6r   m� 56   "   -   5        $ Tamamlananlar��56   I   $��Tamamlananlar��6]   6v   m� 57   "   -	   5        $ İptal Edilenler��57   I   $��İptal Edilenler��6_   6z   m� 58   "   -
   5        $ İncelenecek��58   I   $��İncelenecek��6[   6r   �� 59   "   m� 5:   "   $��
İşlemler��6+   .@�5;   &   m� -   5         m�Name$ 	yeniTalep��5;   /   $��Yeni Talep Ekle��6Z   m� 5<   &   -   5        $ talepGuncelle��5<   /   $��Talebi Güncelle��6b    m� CommandParameter 6{   ��  �� Path$" PlacementTarget.SelectedItem� ��  �� AncestorType" ��m� 5=   &   -   5        $ talepSil��5=   /   $��
Talebi Sil��6X   �� 5>   &   m� 5?   &   -   5        $ BtnTalebeYeniAciklamaEkle��5?   /   $!��Talebe Yeni Açıklama Ekle��6z   m� 5@   &   -   5        $" BtnTalepAciklamalariniGoster��5@   /   $(��"Talebin Açıklamalarını Göster��6�   5A   #   �� 5B   "   m� 5C   "   -   5        $ listeyiYenile��5C   +   $��Yenile��6^   5D         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�61      Header$ Id��6E      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6\   �� *Id+  5H      $ Kullanıcı��61   $ 90 6D    6O   �� *	Departman+  5I      $ 	Departman��61   $ 90 6D    6O   �� *	Kullanici+  5J      $ Başlık��61   $	 190 6A    6M   �� *Baslik+  5K      $ 
Açıklama��61   $	 490 6C    6O   �� *
Aciklama+  5L      $ Durumu��61   $ 75 6A    6L   �� *Durumu+  5M      $ Güncelleme��61   $ 75 6E    6P   �� *Güncelleme+5O      5P      5Q      5R      5S      5T      