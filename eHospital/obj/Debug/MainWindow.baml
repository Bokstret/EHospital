   M S B A M L   `   `   `  ����D  @eHospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:eHospital	eHospital  5   	       eHospital.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:eHospital     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��320��6)    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   $��1q�5      
���������5      �� 5       �� Color$ White��6&   5      �� 5      .+�5       �� -   5        $��CloseButton��5          TransparentButton#��[  5!      $��0, 12, 12, 0q�5"      $��Right=�5#      .��5%      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=�61   5&      �� 5)      $��Center=�6   $��0, 35, 0, 0q�5*      .+�5+      �� $��Images/madhouse.jpg��6   $��80��69   �� 5,      $��eDurka System��6    $��Light"�5-       $��	helvetica)�5.       $��22(�5/       
�������$��Center=�51       $��0, 25, 0, 0q�52       53      54      �� 57      $��1��6   .+�58      �� 	 �� Orientation$	 
Horizontal=�6   $��0, 20, 0, 0q�59      .+�5:      �� -   5        $��
LoginField��5:      $��	helvetica)�5;      $��Light"�5<      $��Login��5=      $��20(�5>      $��Center=�5?      
�������
������ $��0q�5B      $	��233��5C      $
��Left=�5D      
 J� Opacity$	
 0.5Q�5E      $��25��5F      $��34, 0, 0, 0q�5G      5I        5J      $ Account=�61   $��Center=�5K   1   $��Center=�5L   1   ���#5485eb5M   1   5N      �� 5O      $	��250��6   $��2��5P      
�������$	
 0.5Q�5R      �� 5T      $	 
Horizontal=�6   $��0, 20, 0, 0q�66   .+�5U      G� -   5        $��PasswordField��5U   "   $��	helvetica)�5V   "   $��Light"�5W   "    G� Password$ Password��5X   "   $��20(�5Y   "   $��Center=�5Z   "   
�������
������ $��0q�5]   "   $	��233��5^   "   $
��Left=�5_   "   $	
 0.5Q�5`   "   $��25��5a   "   $��34, 0, 0, 0q�5b   "   5d   "     5e      $ FormTextboxPassword=�61   $��Center=�5f   1   $��Center=�5g   1   ���#5485eb5h   1   5i      �� 5j      $	��250��6   $��2��5k      
�������$	
 0.5Q�5m      �� 5p      -   5        $��LoginButton��5p      $	��250��5q      $��30��5r      $��LOGIN��5s        ModernButton#��[ 5t      $��0, 45, 0, 0q�5u      5v      �� 5y      $��Light"�6   $��	helvetica)�5z      $��12(�5{      
�������$��Center=�5}      $��0, 25, 0, 0q�5~      Powered by �� 5   !   .�6&   Team Viplash64   5�      5�      �� 5�      -   5        $��wrongDataText��5�      $��2��5�      $y�	Collapsed=�5�      $��
0, 0, 0 97q�5�      $��Wrong login or password!��5�      
���  ��$��	helvetica)�5�      $��Regular"�5�      $��Center=�5�      $��Bottom=�5�      $��18(�5�      5�      5�      5�      