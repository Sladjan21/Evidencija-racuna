   M S B A M L   `   `   `  ����G  CprikazRacuna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:prikazRacunaprikazRacuna  5   	       prikazRacuna.Racuni   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:prikazRacuna     5   	   -   5          � Title$  Racuni��5   	   $��390.284��6   $��837.919��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid2��5
   /      AutoGenerateColumns .  $
��Left=�6@   $	��219��6[   $��7,56,0,0q�6h   $	��Top=�6z   $	��595��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Broj racuna��6R      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *BR_RAC+6g     5       . $ Datum��6Q   $ * 6`    67   �� *Datum+6`     5       . $ Duguje��6R   $ * 6b    67   �� *Duguje+6b     5       . $ 	Potrazuje��6U   $ * 6h    67   �� *	Potrazuje+6h   5      �� 5   
   -   5        $��btnDodaj��5      $��Dodaj��6!   $
��Left=�61   $��322,327,0,0q�6L   $	��Top=�6a   $	��104��6y   $��24��6�   6�   �� 5   
   $��Duguje��6   $
��Left=�6!   $��
10,284,0,0q�6<   $	��Top=�6P   �� 5   
   $��	Potrazuje��6   $
��Left=�6$   $��201,284,0,0q�6?   $	��Top=�6T   �� 5   
   $��Saldo��6   $
��Left=�6    $��422,284,0,0q�6;   $	��Top=�6P   �� 5   
   -   5        $��tbDuguje��5      $
��Left=�6"   $��23��6=   $��
63,284,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   -   5        $��tbPotrazuje��5      $
��Left=�6%   $��23��6@   $��265,284,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $��tbSaldo��5      $
��Left=�6!   $��23��6<   $��482,284,0,0q�6H   $
 Wrap=�6]   $	��Top=�6r   $	��120��6�   �� 5   
   -   5        $��	btnOsvezi��5      $��Osvezi��6"   $
��Left=�63   $��115,327,0,0q�6N   $	��Top=�6c   $	��102��6{   $��24��6�   6�   �� 5   
   $��Naziv firme��6   $
��Left=�6&   $��	203,6,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        $��tbNazivFirme��5       �� 
IsReadOnly . $
��Left=�68   $��23��6S   $��
284,10,0,0q�6_   $
 Wrap=�6s   $	��Top=�6�   $	��120��6�   �� 5   
   $��Pretrazi racun��6   $
��Left=�6)   $��
600,10,0,0q�6D   $	��Top=�6X   $��86��6p   �� 5   
   -	   5        $��tbRacun��5      $
��Left=�6!   $��23��6<   $��
691,10,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��120��6�   �� 5   
   -
   5        $��btnPretraga��5      $��Pretraga��6$   $
��Left=�67   $��669,253,0,0q�6R   $	��Top=�6g   $��81��6   $��22��6�   &   System.Windows.Controls.Calendar  5   
   -   5        $��calendar��5      $
��Left=�6#   $��
633,56,0,0q�6>   $	��Top=�6R   5!      5"      