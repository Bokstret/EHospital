   M S B A M L   `   `   `  ����D  @eHospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:eHospital	eHospital  5   	       eHospital.WorkingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:eHospital     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	     � Title$  eDurka��5	   	   $	��680��6   $	��910��6%   $	��576��5
   	   $	��860��6    � AllowsTransparency . 
������� � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   $��	helvetica)�5   	   $��Light"�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $��1q�5   	   
�������.��5      ]� .+�5   
   � $
��Left=�6   $	��250��5      .+�5      �� .+�5      �� $��Center=�6   $��0, 20, 0, 0q�5      
�������$��18(�5      eDurka System5      �� 5       -   5         ��Name$ 
doctorName��5       $��26(�5!      $��Center=�5"      $��0, 20, 0, 0q�5#      $
��Wrap=�5$       �� TextAlignment$ Center=�5%      �� 5'      $��0, 40, 0, 0q�6   .+�5(      �� -   5        $��60��5(         NavigationButton#��[  5)      .��5,      ��  �� Orientation$ 
Horizontal=�6%   $	��250��5-   %   .+�5.      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ AccountOutline=�69   $��30��5/   9   $��30��50   9   $��30, 0, 15, 0q�51   9   ���#5485eb52   9   �� 53      $��Me and my patients��6(   $��Center=�54   (   $��18(�55   (   56      57      �� 58      -   5        $��60��58      #��[  59      .��5;      �� $ 
Horizontal=�6%   $	��250��5<   %   .+�5=        $ AccountMultiple=�69   $��30��5>   9   $��30��5?   9   $��30, 0, 15, 0q�5@   9   ���#5485eb5A   9   �� 5B      $��All patients��6(   $��Center=�5C   (   $��18(�5D   (   5E      5F      �� 5G      -   5        $��60��5G      #��[  5H      .��5J      �� $ 
Horizontal=�6%   $	��250��5K   %   .+�5L        $ Doctor=�69   $��30��5M   9   $��30��5N   9   $��30, 0, 15, 0q�5O   9   ���#5485eb5P   9   �� 5Q      $��Doctors��6(   $��Center=�5R   (   $��18(�5S   (   5T      5U      �� 5V      -   5        $��60��5V      #��[  5W      .��5Y      �� $ 
Horizontal=�6%   $	��250��5Z   %   .+�5[        $ 
MedicalBag=�69   $��30��5\   9   $��30��5]   9   $��30, 0, 15, 0q�5^   9   ���#5485eb5_   9   �� 5`      $��	Treatment��6(   $��Center=�5a   (   $��18(�5b   (   5c      5d      5e      5f      �� 5h      $��Center=�6   $��Bottom=�5i      
�������$��0, 0, 0, 15q�5k      Powered by �� 5l      .�6"   Team Viplash60   5m      5o      ]� 5p   
   ���#f5f5f5.+�5q      � -   5        $	��Top=�5q      $��25��5r      ���#f0f0f0.+�5u      �� -   5        $��MinimizeButton��5u        TransparentButton#��[ 5v      $��23��5w      $��Right=�5x      $��0, 0, 56, 0q�5y      .��5{        $ WindowMinimize=�61   5|      �� 5}      -   5        $��MaximizeButton��5}      #��[ 5~      $��Right=�5      $��0, 0, 30, 0q�5�      $��23��5�      .��5�        $ WindowMaximize=�61   5�      �� 5�      -	   5        $��CloseButton��5�      #��[ 5�      $��Right=�5�      $��
0, 0, 4, 0q�5�      $��23��5�      .��5�        $ Close=�61   5�      5�      �� 5�      $
��Auto=�6   .��5�       � -
   5        	  �Name$	 
FramePanel��5�      
  � NavigationUIVisibility$
 Hidden=�5�      5�      5�      5�      5�      