   M S B A M L   `   `   `  ����L  HExtremeTaleplerV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ExtremeTaleplerV2.winsExtremeTaleplerV2.wins  5   	   +    %ExtremeTaleplerV2.wins.winTalepKaydet   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ExtremeTaleplerV2.wins     5   	   -   5          � Title$  winTalepKaydet��5   	   $	��375��6T   $	��500��6a    � WindowStartupLocation$ CenterScreen=�6m    � WindowStyle$
 None=�6�    � AllowsTransparency$
 True��6�   
������ .��5	      � .+�5
   
   �� 
������ .+�5      �� -   5         ��Name$ 	btnKaydet��5      
������ $��0,0,0,0q�6Y    K� ZIndex$ 99��6s    �� Right$ 34��6�    �� Bottom$ 35��6�   $��Center=�6�    �� Left$	 434��6�   
	 �� Top$		 287��6�   $	��Top=�6�   .��5      �� $��	/Save.png��6   5      �� 5      $��30��6   $	��500��6$   $
��Left=�60   $��Center=�6K   ���#4b4b4b$ 10��6u   �� 5      $��
Talep Ekle��6   $ 10��6)   $ 5��6;   $	 1��6K   $��14(�6Z   $
��Bold"�6h   $��Center=�6z   $	��Top=�6�   
�������6�   A� 5      $��50��6   $��50��6!   $ 25��6-   $ 25��6@   
�������$ 10��6_   $��Center=�6q   $	 425��6�   $		 278��6�   $	��Top=�6�   �� 5      $	��500��6   $	��320��6!   $	 30��6.   
 �� CornerRadius$
 	0,0,50,50��6>   ���#3d3d3d J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6'      	Direction$	 -90Q�67      RenderingBias$ Quality=�6G      ShadowDepth$ 2Q�6_   5      5      �� 5      
�������$��Tarih :��6'   $ 15��69   $ 10��6K   $	 35��6\   $��Center=�6l   $��Center=�6�   $��80��6�   
������ $��26��6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ tarih��5      $ 15��6(   $	 109��6:   $	 35��6L   $��Center=�6\   $��26��6y   $��Center=�6�   $	��166��6�   $��Center=�6�   �� 5      
�������$��Departman :��6'   $ 15��6=   
������ $ 10��6h   $	 66��6y   $��Center=�6�   $��Center=�6�   $��80��6�   �� 5      -   5         ��Name$ 	departman��5      $	 109��6*   $ 15��6=   $	 66��6O   $��Center=�6_   $��26��6|   $��Center=�6�   $	��166��6�   �� 5      
�������$��Kullanıcı :��6'   $ 15��6=   
������ $��80��6h   $ 10��6s   $	 99��6�   $��Center=�6�   $	��Top=�6�   �� 5      -   5        $ 	kullanici��5      $	 109��6*   $ 15��6=   $	 99��6O   $��Center=�6_   $��26��6|   $��Center=�6�   $	��166��6�   �� 5       
�������$��
Başlık :��6'   $ 15��6:   
������ $��80��6e   $ 10��6p   $		 130��6�   $��Center=�6�   $	��Top=�6�   �� 5!      -   5         ��Name$ baslik��5!      $	 109��6&   $ 15��69   $		 130��6K   $��Center=�6\   $��26��6y   $	��Top=�6�   $	��166��6�   �� 5"      
�������$��Açıklama :��6'   $ 15��6<   
������ $��80��6g   $ 10��6r   $		 161��6�   $��Center=�6�   $	��Top=�6�   �� 5#      -   5        $ aciklama��5#      $	 109��6(   $ 15��6;   $		 160��6M   $
��Left=�6^   $	��159��6y   $��Center=�6�   $	��300��6�   �� 5&      -   5        $ btnCloseTalepEkle��5&   8   
������� � ToolTip$ Kapat��6(   $	 463��6s   $��X��6�   $ 15��6�   $ 2��6�   $	 6��6�   $
��Left=�6�   $��Center=�6�   $��27��6�   $
��Bold"�6  
������ $��0,0,0,0q�6/  5'      5(      5)      