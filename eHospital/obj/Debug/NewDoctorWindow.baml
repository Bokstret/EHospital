   M S B A M L   `   `   `  ����D  @eHospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:eHospital	eHospital  5   	       eHospital.NewDoctorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:eHospital     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5        $��
ThisWindow��5   	     � Title$  Create new doctor��5	   	   $	��250��6#   $	��400��60    � AllowsTransparency . 
������� � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   $��	helvetica)�5   	   
�������$��1q�5   	   .��5      �� .+�5   
   �� -   5        $��extBtn��5         TransparentButton#��[  5      $��Right=�5      $��
0, 5, 5, 0q�5      $��23��5      .��5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=�6)   5      �� 5   
   $��Create new doctor��6    �� TextAlignment$ Center=�5      $��28(�5      $��Light"�5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��20, 20, 20, 0q�5       $��Center=�5!      .+�5"      �� .+�5#      �� $��Doctor name:��6   $��Light"�5$      $��16(�5%      $��5, 0, 5, 10q�5&      $��Right=�5'      �� 5(      $��Doctor birthdate:��6   $��Light"�5)      $��16(�5*      $��5, 0, 5, 10q�5+      $��Right=�5,      �� 5-      $��Doctor cabinet:��6   $��Light"�5.      $��16(�5/      $��5, 0, 5, 10q�50      $��Right=�51      �� 52      $��Doctor password:��6   $��Light"�53      $��16(�54      $��5, 0, 5, 10q�55      $��Right=�56      57      �� 58      .+�59      �� $��Light"�6   $��16(�5;      
������ $��0q�5=      $	��175��5>      ��5:      �� *Name+5>      �� 5?      $	��175��6   $��2��5@      
���   � J� Opacity$	 0.5Q�5B      $��
0, 0, 0, 8q�5C      �� 5D      -   5        	 ��Name$	 docBirthField��5D      $��Light"�5E      $��16(�5G      
������ $��0q�5I      $	��175��5J      ��5F      �� *	Birthdate+5K      �� 5L      $	��175��6   $��2��5M      
���   �$	 0.5Q�5O      $��
0, 0, 0, 8q�5P      �� 5Q      -   5        $	 docCabinetField��5Q      $��Light"�5R      $��16(�5T      
������ $��0q�5V      $	��175��5W      ��5S      �� *	Cabinet+5X      �� 5Y      $	��175��6   $��2��5Z      
���   �$	 0.5Q�5\      $��
0, 0, 0, 8q�5]      �� 5^      $��Light"�6   $��16(�5`      
������ $��0q�5b      $	��175��5c      ��5_      �� *
Password+5c      �� 5d      $	��175��6   $��2��5e      
���   �$	 0.5Q�5g      $��
0, 0, 0, 8q�5h      5i      5j      �� 5k   
   $ 
Horizontal=�6   $��Center=�5l      $��0, 12, 0, 0q�5m      .+�5n      �� -   5        
 ��Name$
 addNewNurse��5n        ModernButton#��[ 5o      $��Create nurse��5p      $��Center=�5q      $	��115��5r      $��23��5s      $��16(�5t      $��0, 0, 20, 0q�5u      $��0��5w      ��5v      �� *	AddNewDoc+5w      �� 5x      -   5        $
 addNewDoctor��5x      #��[ 5y      $��Create doctor��5z      $��Center=�5{      $	��115��5|      $��23��5}      $��16(�5~      $��20, 0, 0, 0q�5      $��1��5�      ��5�      �� *	AddNewDoc+5�      5�      5�      5�      