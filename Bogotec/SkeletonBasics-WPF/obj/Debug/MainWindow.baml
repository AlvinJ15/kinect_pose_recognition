   M S B A M L   `   `   `  ����  SkeletonBasics-WPF8    2Microsoft.Samples.Kinect.SkeletonBasics.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          � Title$  Skeleton Basics��5   	   $	��735��6!   $��839.948��6.    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush �� 
TargetType �� Property �� Value  SquareCheckBox �� 
TargetType �� Orientation �Name	 ��Name
 ��Name �� TextAlignment �� Triggers P� Property P� Value �� 
TargetName��%1  &	        &	 #     &	 F     '�� i     &	 �     7  7  �� 5   
   $ 	#ff6e6e6e��62   �� 5	   
   $ 	#ff52318f��64   �� 5
   
   $ 	#ff00BCF2��62   �� 5   
   " ��6   .�5      ��  �@J�SnapsToDevicePixels . 64   5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 
Horizontal=�6)   
������ .+�5   "   � $ SquareCheckBoxChecked��6'   .+�5   &   �� $	 CheckedNormal��6,   $��Images\CheckedNormal.png��6C   $
��None=�6e   $��Center=�6t   �� 5   &   $	 CheckedHover��6,   $��Images\CheckedHover.png��6B   $
��None=�6c   $��Center=�6r   $y�	Collapsed=�6�   5   #   � 5   "   $ SquareCheckBoxUnchecked��6'   $y�	Collapsed=�6H   .+�5   &   �� $	 UncheckedNormal��6,   $ ��Images\UncheckedNormal.png��6E   $
��None=�6i   $��Center=�6x   �� 5   &   $	 UncheckedHover��6,   $��Images\UncheckedHover.png��6D   $
��None=�6g   $��Center=�6v   $y�	Collapsed=�6�   5   #   �� 5   "   $
 SquareCheckBoxText��6,   #��z��6H   $
 Left=�6i   $��Center=�6   8��  $��15(�6�   $��9,0,0,0q�6�   5      5       5      P� 5        �@d�	IsChecked$ falseY�6;   . �5!   "   �� $ SquareCheckBoxChecked��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5"   "   $ SquareCheckBoxUnchecked��6O    � y�$ Visible=�6?   6O   5#      P� 5$       �@J�IsMouseOver . . �5%   "   �� $ CheckedNormal��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5&   "   $ UncheckedNormal��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5'   "   $ CheckedHover��6O    � y�$ Visible=�6?   6O   �� 5(   "   $ UncheckedHover��6O    � y�$ Visible=�6?   6O   �� 5)   "   8  $ SquareCheckBoxText��6h    � ��5*      5,      5.      5/      50      .��52      � -   5        $ 
layoutGrid��52      $��	10 0 10 0q�6    � RowDefinitions 53   
   �� 54      $
��Auto �6   �� 55      $��* �6   �� 56      $
��Auto �6   �� 57      $
��Auto �6   .+�59   
   ]� $��0��6   $��0 0 0 20q�6!   .+�5:      �� $
��Left=�6   $��Images\Logo.png��6*   $
��Fill=�6C   $��32��6R   $��81��6^   $��0 10 0 5q�6i   �� 5;      $��Right=�6   $��0 0 -1 0q�6/   $��Bottom=�6A   #��[  6\   $��Segoe UI)�6�   $��18(�6�   �� 6�   $�Skeleton Basics��6�   6�   �� 5<      $��1��6   $��Images\Status.png��6$   $
��None=�6?   $��Center=�6N   $��0 0 0 5q�6k   5=      (� 5>   
   $��1��6    (� Stretch$ Uniform=�6   $��Right=�61   .��5?      �� -   5        $	 Image��5?      $	��561��6#   $	��480��6/   5@      �� 5A   
   -   5         ��Name$ checkBoxSeatedMode��5A   �   $��2��6   #��[ 6    $��Seated Mode��6H   $
��Auto��6^   $
��Left=�6l   $��Center=�6�   $��
0 10 10 10q�6�   6�   �� 5B   
   -   5         ��Name$ 	statusBar��5B   ?   $��3��6   $��Stretch=�6!   $��Bottom=�6R   
�������#��[  6�   .@�5C      �� $��0 0 0 10q�6   .��5D      �� -   5        $
 statusBarText��5D      $��-1 0 0 0q�63   �� 6F   $6�0Click 'Seated' to change skeletal pipeline type!��6J   6�   5E      5F      �� 5G   
   -   5        $��Parte��5G      $
��Left=�6   $��23��6:   $��	10,10,0,0q�6F   $��1��6Y    �� TextWrapping$
 Wrap=�6f   $��Nombre��6z   $	��Top=�6�   $	��120��6�   6�   �� 5H   
   -   5        $��Estado��5H      $
��Left=�6    $��41��6;   $��	10,33,0,0q�6G   $��1��6Z   $
 Wrap=�6g   $��Listo��6{   $	��Top=�6�   $	��575��6�   $��36(�6�   $��Arial Black)�6�   �� 5I   
   -	   5        $
��Posi��5I      $
��Left=�6   $��23��69   $��
10,125,0,0q�6E   $��1��6Y   $
 Wrap=�6f   $��TextBox��6z   $	��Top=�6�   $	��120��6�   �� 5J   
   -
   5        $��RightArm��5J      $
��Left=�6"   $��23��6=   $��	10,79,0,0q�6I   $��1��6\   $
 Wrap=�6i   $��TextBox��6}   $	��Top=�6�   $	��120��6�   �� 5K   
   -   5        $��Other��5K      $
��Left=�6   $��23��6:   $��
10,102,0,0q�6F   $��1��6Z   $
 Wrap=�6g   $��TextBox��6{   $	��Top=�6�   $	��120��6�   �� 5L   
   -   5        $
��Play��5L      $
��Left=�6    $��
31,301,0,0q�6;   $��1��6O   $	��Top=�6\   $��75��6t   6   �� 5M   
   -   5        $
��Stop��5M      $
��Left=�6    $��
31,321,0,0q�6;   $��1��6O   $	��Top=�6\   $��75��6t   6   5O      5P      