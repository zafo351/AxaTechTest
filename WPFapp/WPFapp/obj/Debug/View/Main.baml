   M S B A M L   `   `   `  ����A  =WPFapp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFapp.ViewWPFapp.View  5          WPFapp.View.Main   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPFapp.View     5        N� Title$
  Main��5	       N� 
Background
 �����.��5      �  � ShowGridLines .  � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      6!   .+�5   
   �� -   5        $��
BtnNewUser��5      $��0 50 0 0q�5      $��0��5      $	��200��5      $��40��6   $��Center=�5      $	��Top=�5      
���   �$��2q�5      .��6:   
New User6D   �� 5   
   -   5        $��BtnListUser��5      $��0 0 0 0q�5      $��0��5      $	��200��5      $��40��6   $��Center=�5       $��Center=�5!      
���   �$��2q�5#      .��6;   
List Users6G   �� 5$   
   -   5        $��BtnListAreas��5$      $��0 0 0 50q�5%      $��0��5&      $	��200��5'      $��40��6   $��Center=�5(      $��Bottom=�5)      
���   �$��2q�5+      .��6@   
List Areas6L   �� 5-   
   -   5         ��Name$ TitleOfDataGrid��5.      $��1��5/      $��Center=�50      $	��Top=�51      See the last 10 users created53      &   System.Windows.Controls.DataGrid  55   
   -   5        $��	DataGrid1��56      $��0 20 0 0q�57      $��1��58         AutoGenerateColumns .     
IsReadOnly .    Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ Id User��5=      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5>      �� *IdUser+62     5?      $ 
First Name��5@      	 5A      �� *	FirstName+65     5B      $ 	Last Name��5C      	 5D      �� *
LastName+64     5E      $ Email��5F      	 5G      �� *EmailAddress+68     5H      $ Phone��5I      	 5J      �� *Phone+61     5K      $ Id Area��5L      	 5M      �� *IdArea+62   5P      5Q      5R      