   M S B A M L   `   `   `  ����D  @Kursovaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Kursovaya	Kursovaya  5   	       Kursovaya.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Kursovaya     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Окно заметок��5	   	   $	��600��6   $	��800��6+    � 
ResizeMode$ CanMinimize=�67    � 	Resources 5
       �� 
TargetType �� Property �� Value��%Q  '��       '�� �     '�� d    '� �    �� 5   
   " ��6   .�5      ��  � ��$ Segoe Print)�6+   �� 5       � �� �	#FFF3EBBA6+   �� 5       � ��
 �   �6+   �� 5       � ��$ 12(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Segoe Print)�6+   �� 5       � ��
 ��iA�6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 	Open Sans)�6+   �� 5       � �� �	#FFF7F2D76+   5      �� 5   
   " �6   .�5      ��  � ��
 ��iA�6+   5      5      .��5      �  � ShowGridLines$ False��6    � ColumnDefinitions 5   
   �� 5       $
��410* �6   �� 5!      $
��391* �6   	 � RowDefinitions	 5#   
   �� 5$      $��0.25* �6   �� 5%      $
��0.6* �6   �� 5&      $
��3.5* �6   .+�5(   
   �� $��0 0 0 2q�6   
����d�$��2��6H   ._�5)      �� 
 �� TextAlignment$
 Center=�6   $��23(�6/   $��1��6=   $��1��6Q   $��0,-7,0,0q�6b    J� RenderTransformOrigin$ 	0.5,0.241&�6t   Все заметки5+      5,      �� 5-   
   $
��15.5(�6   $
 Center=�6$   $��165,5,165,0q�6;   $��1��6P   $	��Top=�6]   $��2��6u   $��28��6�   Поиск:6�   �� 5.   
   -   5         ��Name$ 
nameSearch��5.      $��1��6&   $��25��63    �� TextWrapping$
 Wrap=�6?   $�� ��6S   $	��442��6[   $��179,33,179,22q�6g   $��2��6�   �� 5/   
   -   5         ��Name$ fieldOfWrites��5/      $��2��6)   $��0 2 0 0q�66   
����d�$��2��6m   50      �� 51   
   $��3��6   $	��600��6"   $��Bottom=�6/   $��2��6J   .+�52      �� -   5         ��Name$ newWrite��52      $#��Создать заметку��6'    �� Bottom$ 20��6A    �� Left$	 321��6T   $��59��6}   $��14(�6�   $��2q�6�   
 �� Top$	 510��6�   $	��158��6�   
�������
����iA�6�   53      54      55      