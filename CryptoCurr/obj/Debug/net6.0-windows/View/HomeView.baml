   M S B A M L   `   `   `  ����E  ACryptoCurr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CryptoCurr.ViewCryptoCurr.View  5          CryptoCurr.View.HomeView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CryptoCurr.View     5      .��5	      � .+�5
   
   �� $��
Currencies��6   $��30(�5      
�������$��40,0,0,0q�5      �� 5   
     �� CornerRadius$  20��6   ���#17123d$	��625��5      $��50��5      $��	0,0,0,300q�5      ._�5      � .+�5      �� $��Search By Name:��6   
�������$��Center=�5      $
��Left=�5      $��30,0,0,0q�5      �� 5      -   5         ��Name$ TextBox��5      ���#353340
�������$	��100��5      $��20��5      $��	0,0,260,0q�5      �� 5       $��Search By Symbol:��6   
�������$��Center=�5"      $��Center=�5#      $��90,0,0,0q�5$      �� 5%      -   5        $��TextBox1��5%      ���#353340
�������$	��100��5(      $��20��5)      $��	300,0,0,0q�5*      5+      5,      &   System.Windows.Controls.DataGrid  5.   
   -   5        $��
DbCurrency��5.      $	��700��5/      $	��300��50      $��
40,80,40,0q�51         Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6%      Header$ Id��54   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 55   %   �� *Id+  56      $	 160 6%   $ Price��57   %    58   %   �� *Cost+  59      $	 160 6%   $
 Name��5:       5;      �� *Name+  5<      $	 140 6%   $ Symbol��5=       5>      �� *Symbol+  5?      $	 140 6%   $ Description��5@       5A      �� *Description+5C      5D      5E      