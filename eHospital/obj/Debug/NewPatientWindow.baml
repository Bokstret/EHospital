   M S B A M L   `   `   `  ����D  @eHospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:eHospital	eHospital  5   	        eHospital.NewPatientWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:eHospital     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5        $��
ThisWindow��5   	     � Title$  Add new patient��5	   	   $	��250��6!   $	��400��6.    � AllowsTransparency . 
������� � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	   $��	helvetica)�5   	   
�������$��1q�5   	   .��5      �� .+�5   
   �� -   5        $��extBtn��5         TransparentButton#��[  5      $��Right=�5      $��
0, 5, 5, 0q�5      $��23��5      .��5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=�6)   5      �� 5   
   $��Add new patient��6    �� TextAlignment$ Center=�5      $��28(�5      $��Light"�5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��20, 10, 20, 0q�5       $��Center=�5!      .+�5"      �� .+�5#      �� $��Patient name:��6   $��Light"�5$      $��16(�5%      $��5, 0, 5, 10q�5&      $��Right=�5'      �� 5(      $��Patient birthdate:��6   $��Light"�5)      $��16(�5*      $��5, 0, 5, 10q�5+      $��Right=�5,      �� 5-      $��Patient cell number:��6   $��Light"�5.      $��16(�5/      $��5, 0, 5, 10q�50      $��Right=�51      �� 52      $��Patient disease:��6   $��Light"�53      $��16(�54      $��5, 0, 5, 10q�55      $��Right=�56      �� 57      $��Patient info:��6   $��Light"�58      $��16(�59      $��
5, 0, 5, 3q�5:      $��Right=�5;      5<      �� 5=      .+�5>      �� $��Light"�6   $��16(�5@      
������ $��0q�5B      $	��175��5C      ��5?      �� *Name+5C      �� 5D      $	��175��6   $��2��5E      
���   � J� Opacity$	 0.5Q�5G      $��
0, 0, 0, 8q�5H      �� 5I      -   5        	 ��Name$	 patBirthField��5I      $��Light"�5J      $��16(�5L      
������ $��0q�5N      $	��175��5O      ��5K      �� *	Birthdate+5P      �� 5Q      $	��175��6   $��2��5R      
���   �$	 0.5Q�5T      $��
0, 0, 0, 8q�5U      �� 5V      -   5        $	 patRoomNumField��5V      $��Light"�5W      $��16(�5Y      
������ $��0q�5[      $	��175��5\      ��5X      �� *
Room_num+5]      �� 5^      $	��175��6   $��2��5_      
���   �$	 0.5Q�5a      $��
0, 0, 0, 8q�5b      �� 5c      $��Light"�6   $��16(�5e      
������ $��0q�5g      $	��175��5h      ��5d      �� *
Diseases+5h      �� 5i      $	��175��6   $��2��5j      
���   �$	 0.5Q�5l      $��
0, 0, 0, 8q�5m      �� 5n      $��Light"�6   $��16(�5p      
������ $��0q�5r      $	��175��5s      ��5o      �� *Info+5s      �� 5t      $	��175��6   $��2��5u      
���   �$	 0.5Q�5w      $��
0, 0, 0, 8q�5x      5y      5z      �� 5{   
   -   5        
 ��Name$
 	addNewPat��5{        ModernButton#��[ 5|      $��Add patient��5}      $��Center=�5~      $	��115��5      $��23��5�      $��16(�5�      $��
0, 4, 0, 0q�5�      ��5�      �� *	AddNewPat+5�      5�      