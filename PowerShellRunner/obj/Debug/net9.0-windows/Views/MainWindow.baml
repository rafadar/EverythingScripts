   M S B A M L   `   `   `  ����K  GPowerShellRunner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PowerShellRunner.ViewModelsPowerShellRunner.ViewModels  5   	   '    !PowerShellRunner.Views.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;local)clr-namespace:PowerShellRunner.ViewModels     5   	     � Title$  PowerShell Runner��5   	   $	��450��6#   $	��800��60    � DataContext 5      5   /PowerShellRunner.ViewModels.MainWindowViewModel  5   
   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� $	��200��5      $��0,0,10,0q�5      ��5      �� *	Scripts+ �� SelectedItem 5      �� *SelectedScript+5      �� 5       �� DisplayMemberPath$ 
TenantName��5      $	��200��5      $��0,0,10,0q�5      ��5      �� *	Tenants+ 5      �� *SelectedTenant+5      �� 5      $��Load Parameters��6   ��6/   �� *LoadParametersCommand+5      �� 5   
   $��1��6:   $��10q�6G   ��6   �� *
Parameters+��5      �� 5      .R�5       �� $ 
Horizontal=�6!   .+�5!      �� $	��100��6:   ��6$   �� *Name+6:   �� 5"      $	��200��6^   ��6"   �� *Value+ �� UpdateSourceTrigger$ PropertyChanged=�6^   5#      5$      5&      �� 5(   
   $��2��6   $��10q�6    �� AcceptsReturn$
 True��5*      " �� VerticalScrollBarVisibility$
 Auto=�5+      	 �� 
IsReadOnly$
	 True��5,      $	��100��5-      ��5)      �� *ExecutionOutput+5-      5.      5/      