   M S B A M L   `   `   `  ���� C  ?LotesWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LotesWPFLotesWPF      LotesWPF.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:LotesWPF       � Title$  Procesamiento por lotes��$��720         ��$
��1280�� � Icon$ 	/logo.ico�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.��� ���#0B735E � ColumnDefinitions �� $
��1.5* ��� $��2* � � RowDefinitions �� $��* ��� $��3* ��� $��3* �.+��� $��0��$��2��$��2q�
��������� $��1��$��2��$��2q�
��������� $��2��$��2��$��2q�
��������� -    ��Name$ TbNumProcesos��$��1��$	��200��$��
70,35,0,36q�$
��Left=�$��20(�
����������#0A6654�� $��Center=�$��Center=�
�������$��22(�$��29��$	��404��*(Proceso por lotes con Multiprogramación�� $��1��$	��Top=�$
��Left=�$��20(�
�������$��
455,30,0,0q�$��53��$	��235��Carlos Alberto Ceja Zapata�� Juan Ródríguez Tabares�� $��1��$
��Left=�$��	70,5,0,71q�
�������$��20(�$	��200��Numero de procesos�� -    ��Name$ 	BtnInicio��$��1��$	��150��$��40�����#0A6654
�������$��20(����	#FF056679$��Center=�$
��Left=�$��	300,0,0,0q� J� RenderTransformOrigin$ 166,0&�	 � Cursor$
	 Hand��.��	Iniciar�� -   
 ��Name$
 LbPendientes��$��1��
�������$��20(�$��Right=�$	��Top=�$��	0,10,60,0q�Lotes Pendientes:�� $��1��
�������$��20(�$
��Left=�$	��Top=�$��	30,10,0,0q�Lote en ejecución&   System.Windows.Controls.DataGrid  -     Name$ DgvLotes��$��1��   AutoGenerateColumns .  $	��550��$	��250��$��Bottom=�   
IsReadOnly . $��18(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ProcessID+  $
 Lote��$ *  �� *
NumeroLote+  $ Valor 1��$ *  �� *FValue+  $
 Tipo��$ *  �� *
Operator+  $ Valor 2��$ *  �� *SValue+  $ Tiempo��$ *  �� *	MaxTime+�� -   $
 TbTemporizador��$��1��$��1��$��20(�
�������$��10,0,0,0q�$��Center=�$	��Top=�Temporiador Global: 0�� -   $

 TbID��$��1��$��1��$��20(�
�������$��	50,50,0,0q�$
��Left=�$	��Top=�ID:�� -   $
 TbValor1��$��1��$��1��$��20(�
�������$��	50,0,0,60q�$
��Left=�$��Center=�
Valor 1:�� -   $
 
TbOperator��$��1��$��1��$��20(�
�������$��
50,0,0,100q�$
��Left=�$��Bottom=�
Operacion:�� -	   $
 TbValor2��$��1��$��1��$��20(�
�������$��	50,0,0,40q�$
��Left=�$��Bottom=�
Valor 2:�� -
   $
 TbTime��$��1��$��1��$��20(�
�������$��
0,50,100,0q�$��Right=�$	��Top=�Tiempo Maximo:�� -   $
 	TbTimeRes��$��1��$��1��$��20(�
�������$��0,50,100,60q�$��Right=�$��Center=�Tiempo Restante:�� -   $
 TbTimeTrans��$��1��$��1��$��20(�
�������$��0,50,100,50q�$��Right=�$��Bottom=�Tiempo Transcurrido:�� $��2��$��20(�
�������$��	10,10,0,0q�$
��Left=�$	��Top=�Procesos finalizados  -   $ DgvFinalizados��$��2��$��2�� .  $
��auto��$	��250��$��
10,0,10,10q�$��Bottom=� . $��18(�   $ ID��$ *  �� *	ProcessID+  $ Estado��$ *  �� *Status+  $ Valor 1��$ *  �� *FValue+  $
 Tipo��$ *  �� *
Operator+  $ Valor 2��$ *  �� *SValue+  $ 	Resultado��$ *  �� *Result+  $ Tiempo��$ *  �� *	MaxTime+  $ No Lote��$ *  �� *
NumeroLote+