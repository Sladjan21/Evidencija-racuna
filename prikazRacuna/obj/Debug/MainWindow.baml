   M S B A M L   `   `   `  ����G  CprikazRacuna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:prikazRacunaprikazRacuna  5   	       prikazRacuna.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:prikazRacuna     5   	   -   5          � Title$  
MainWindow��5   	   $��390.284��6   $	��800��6-   .��5	      � .+�5
   
   o�  o� 
IsMainMenu . $
��Left=�6!   $��20��6<   $	��Top=�6H   $��50��6`   .@�5      m� $
��Meni��6   .@�5      m� -   5        $��Pregled racuna��5      63   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dataGrid1��5         AutoGenerateColumns .  $
��Left=�6@   $	��211��6[   $��	10,66,0,0q�6h   $	��Top=�6{   $	��774��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Naziv��6Q      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Naziv+6`     5       . $	 PIB��6Q   $ * 6^    67   �� *IDPIB+6^     5       . $ MB��6N   $ * 6Z    67   �� *MB+6Z     5       . $ Sediste��6S   $ * 6d    67   �� *	Sediste+6d     5       . $ Tekuci racun��6N   $ * 6d    67   �� *TR+6d      RowDetailsTemplate 5      �� 5      .R�5      �� $��10q�6   ._�5      � 	 � ColumnDefinitions	 5      �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5   "   $	��100 �63   �� 5    "   $	��100 �63   �� 5!   "   $	��100 �63   
 � RowDefinitions
 5#      �� 5$   "   $��* �60   .+�5&      �� $��Duguje��6$   $��0��65   $��0��6B   �� 5'      $��tbDuguje��68    �� 
IsReadOnly . $��0��6H   $��1��6U   �� 5(      $��0��6$   $��2��61   $��	Potrazuje��6A   �� 5)      $��tbPotrazuje��68    . $��0��6K   $��3��6X   �� 5*      $��0��6$   $��4��61   $��Saldo��6A   �� 5+      $��tbSaldo��68    . $��0��6G   $��5��6T   5,      5-      5.      50      �� 51   
   $��Pretraga��6   $
��Left=�6#   $��
116,25,0,0q�6>   $	��Top=�6R   $��57��6j   �� 52   
   -   5        $��
tbPretraga��52      $
��Left=�6$   $��23��6?   $��
178,25,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��139��6�   �� 53   
   -   5        $��btnPretrazi��53      $��Pretrazi��6$   $
��Left=�67   $��
340,28,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 54   
   -   5        $��btnNova��54      $
��Nova��6    $
��Left=�6/   $��
73,307,0,0q�6J   $	��Top=�6^   $��75��6v   6�   �� 55   
   -   5        $��	btnIzmeni��55      $��Izmeni��6"   $
��Left=�63   $��316,307,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 56   
   -   5        $��
btnIzbrisi��56      $��Izbrisi��6#   $
��Left=�65   $��546,307,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 57   
   -	   5        $��	cmbFilter��57      $
��Left=�6$   $��
594,23,0,0q�6?   $	��Top=�6S   $	��120��6k   �� 58   
   $��Filter pretrage��6   $
��Left=�6*   $��
480,23,0,0q�6E   $	��Top=�6Y   5:      5;      