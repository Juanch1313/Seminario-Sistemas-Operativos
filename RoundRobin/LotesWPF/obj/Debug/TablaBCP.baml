   M S B A M L   `   `   `  ����C  ?LotesWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LotesWPFLotesWPF  5   	       LotesWPF.TablaBCP   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:LotesWPF     5   	   -   5          � Title$  TablaBCP��5   	   $	��720��6   $
��1080��6'    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�5
   	    � Icon$ logo.ico��5   	   .��5      � ���#0B735E � ColumnDefinitions 5   
   �� 5      .+�5   
   �� 
�������$��5q�6%   �� 5   
   $��Center=�6   $	��Top=�61   $��0,10,0,0q�5      
�������$��30(�5      	Tabla BCP5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgvBCP��5         AutoGenerateColumns .  $	��Top=�5         
IsReadOnly . $��30,60,30,30q�5      $	��600��6(   $��18(�5      $��Center=�6!   
���   �$��5q�5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 35 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProcessID+6\     5"      $	 Estado��6%   $
 * 6P    65   �� *Status+6\     5#      $	 Valor 1��6%   $
 * 6Q    66   �� *FValue+6]     5$      $	 Valor 2��6%   $
 * 6Q    66   �� *SValue+6]     5%      $	 
Operación��6%   $
 * 6U    68   �� *
Operator+6a     5&      $	 	Resultado��6%   $
 * 6S    68   �� *Result+6_     5'      $	 TM��6%   $
 60 6M    61   �� *	MaxTime+6Z     5(      $		 TLL��6%   $
 60 6Q    62   �� *
ComingTime+6^     5)      $	 TF��6%   $
 60 6P    61   �� *
FinishTime+6]     5*      $
	 TRes��6%   $
 70 6Q    63   �� *	AswerTime+6^     5+      $	 TR��6%   $
 60 6P    61   �� *
ReturnTime+6]     5,      $	 TE��6%   $
 60 6N    61   �� *
WaitTime+6[     5-      $	 TS��6%   $
 60 6O    61   �� *	TransTime+6\     5.      $	 TB��6%   $
 60 6O    61   �� *	BloqTimer+6\   51      52      53      