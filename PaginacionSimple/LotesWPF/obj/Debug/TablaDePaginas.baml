   M S B A M L   `   `   `  ����C  ?LotesWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LotesWPFLotesWPF  5   	       LotesWPF.TablaDePaginas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:LotesWPF     5   	     � Title$  TablaDePaginas��5   	   $	��720��6    $
��1280��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�5
   	   .��5      � ���#0B735E � ColumnDefinitions 5   
   �� 5      .+�5   
   �� 
�������$��5q�6%   �� 5   
   $��Center=�6   $	��Top=�61   $��0,10,0,0q�5      
�������$��30(�5      Tabla de paginas5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
DgvPaginas��5         AutoGenerateColumns .  $	��Top=�5         
IsReadOnly . $��30,60,30,30q�5      $	��600��6(   $��18(�5      $��Center=�6!   
���   �$��5q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Proceso��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *	ProcessID+6`     5      $ Tamaño��6%   $	 * 6N   
 65   �� *Size+6Z     5       $ Marcos��6%   $	 * 6P   
 65   �� *Marcos+6\     5!      $ Frames��6%   $	 * 6P   
 65   �� *Frames+6\   5$      5%      5&      