   M S B A M L   `   `   `  ����I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EmotionalDiaryEmotionalDiary  5   	       EmotionalDiary.Game   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EmotionalDiary     5   	     � Title$  
MainWindow��5      $	��800��6$   $	��800��61    � 	Resources 5	         TextBoxStyle �� 
TargetType �� Property �� Value  TextBlockStyle��%S  &	        &	 }    �� 5
   
   " ��6%   .�5      ��  � ��$ 80(�6)   �� 5       � ��$	 110��6&   �� 5       � ��$	 110��6'   �� 5       � ��$ 23q�6'   �� 5       � �� �#FFFFFF6+   �� 5       � �� �#E14D2A6+   �� 5       � ��$ 0q�60   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6'   .�5      ��  � ��$ 50(�6)   �� 5       � �� �#0000006+   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   5      5      .��5      � .+�5   
   � -   5         �Name$ 
gameScreen��5      $y�Visible=�6#   ���#F7EEDD � RowDefinitions 5      �� 5      $��4* �6    �� 5       $��1* �6    .+�5"      � -   5        $ mainGrid��5"       � ShowGridLines$
 True��6%    � ColumnDefinitions 5#      �� 5$      $��1* �6'   �� 5%      $��1* �6'   �� 5&      $��1* �6'   �� 5'      $��1* �6'    5)      �� 5*      $��1* �6$   �� 5+      $��1* �6$   �� 5,      $��1* �6$   �� 5-      $��1* �6$   .+�5/      �� -   5        $�� ��5/      $	��120(�6$   $��Center=�63   $��Center=�50      $
��Wrap=�6   60   �� 51      -   5        $�� ��51      $	��120(�6$   $��Center=�63   $��Center=�52      $��1��6   $
��Wrap=�6,   6@   �� 53      -   5        $�� ��53      $	��120(�6$   $��Center=�63   $��Center=�54      $��2��6   $
��Wrap=�6,   6@   �� 55      -   5        $�� ��55      $	��120(�6$   $��Center=�63   $��Center=�56      $��3��6   $
��Wrap=�6,   6@   �� 57      -   5        $�� ��57      $	��120(�6$   $��Center=�63   $��Center=�58      $��1��6   $
��Wrap=�6*   6>   �� 59      -   5        $�� ��59      $	��120(�6$   $��Center=�63   $��Center=�5:      $��1��6   $��1��6)   $
��Wrap=�69   6M   �� 5;      -	   5        $�� ��5;      $	��120(�6$   $��Center=�63   $��Center=�5<      $��1��6   $��2��6)   $
��Wrap=�69   6M   �� 5=      -
   5        $�� ��5=      $	��120(�6$   $��Center=�63   $��Center=�5>      $��1��6   $��3��6)   $
��Wrap=�69   6M   �� 5?      -   5        $�� ��5?      $	��120(�6$   $��Center=�63   $��Center=�5@      $��2��6   $
��Wrap=�6*   6>   �� 5A      -   5        $�� ��5A      $	��120(�6$   $��Center=�63   $��Center=�5B      $��2��6   $��1��6)   $
��Wrap=�69   6M   �� 5C      -   5        $�� ��5C      $	��120(�6$   $��Center=�63   $��Center=�5D      $��2��6   $��2��6)   $
��Wrap=�69   6M   �� 5E      -   5        $�� ��5E      $	��120(�6$   $��Center=�63   $��Center=�5F      $��2��6   $��3��6)   $
��Wrap=�69   6M   �� 5G      -   5        $�� ��5G      $	��120(�6$   $��Center=�63   $��Center=�5H      $��3��6   $
��Wrap=�6*   6>   �� 5I      -   5        $�� ��5I      $	��120(�6$   $��Center=�63   $��Center=�5J      $��3��6   $��1��6)   $
��Wrap=�69   6M   �� 5K      -   5        $�� ��5K      $	��120(�6$   $��Center=�63   $��Center=�5L      $��3��6   $��2��6)   $
��Wrap=�69   6M   �� 5M      -   5        $�� ��5M      $	��120(�6$   $��Center=�63   $��Center=�5N      $��3��6   $��3��6)   $
��Wrap=�69   6M   5O      � 5P      $��1��6    5Q      �� 5R      $��1* �6$   .+�5T      �� -   5        	 ��Name$	 TimeTextBlock��5T      $��Center=�63   $
��Wrap=�6P   $�� ��6d   $��Center=�6l   $��4��6�   $��50(�6�   5U      5V      �� 5W   
   -   5        
 ��Name$
 answerScreen��5W      $y�Hidden=�6+   ���#F7EEDD.+�5X      �� #��[ 6   앞에서 눌린 숫자들을6M   �� 5Y      #��[ 6   " 순서대로 입력해주세요!6N   �� 5[       �� Orientation$ 
Horizontal=�6   .+�5\      �� -   5         ��Name$ TextBox1��5\      #��[  6F   6n   �� 5]      -   5        $ TextBox2��5]      #��[  6F   6n   �� 5^      -   5        $ TextBox3��5^      #��[  6F   6n   �� 5_      -   5        $ TextBox4��5_      #��[  6F   6n   �� 5`      -   5        $ TextBox5��5`      #��[  6F   6n   �� 5a      -   5        $	 printe��5a      $��50(�6,   6<   5b      �� 5c      -   5        $
 output��5c      .+�5d      �� -   5        $	 average_response��5d      #��[ 66   $��
45 20 45 0q�6^   6t   �� 5e      -   5        $	 
answer_num��5e      #��[ 60   $��
45 20 45 0q�6X   6n   �� 5f      -   5        $
 reaction_age��5f      $��Center=�63   $��Center=�6P   $y�Hidden=�6k   $ 
Horizontal=�6   .+�5g      �� #��[ 6    $��
45 20 25 0q�6H   반응속도 나이 :6g   �� 5h      -   5        $	 responseAge��5h       #��[ 65   $��0 20 0 0q�6]   6q   5i      �� 5j      -    5        $
 
memory_age��5j      $��Center=�61   $��Center=�6N   $y�Hidden=�6i   $ 
Horizontal=�6}   .+�5k      �� #��[ 6    $��
45 20 25 0q�6H   기억력 나이 :6f   �� 5l      -!   5        $	 	memoryAge��5l       #��[ 63   $��0 20 0 0q�6[   6o   5m      5n      �� 5o      -"   5        $
	 test��5o      6(   �� 5p      $ 
Horizontal=�6   .+�5q      �� -#   5        $	 	try_again��5q      #��[ 6/   $y�Hidden=�6W   6m   �� 5r      -$   5         ��Name$ ok��5r      $y�Hidden=�6%   $��80��6P   $��80��6[   $��80, 0, 20, 0q�6g   ��5s      �� 5t      " ��6    .�5u      ��  � �� �#E14D2A6;   �� 5v       � ��
 �����6;   �� 5w       � ��$ 20(�69   �� 5x       � ��$
 Bold"�6;   �� 5y       � ��$
 10,5q�68   �� 5z       � ��$ 0q�6@   �� 5{       � �� 5|   "   �� 5}   &    �� 
TargetType" ��66   .R�5~   *   �� #��z��61   #��z��5      #��z��5�       �� CornerRadius$ 10��5�      ._�5�   .   �� $��Center=�6?   $��Center=�6\   5�   +   5�   '   5�      5�      .��5�   $   네5�      �� 5�      -%   5        $ no��5�      $y�Hidden=�6%   $��80��6P   $��80��6[   $��20, 0, 20, 0q�6g   ��5�      �� 5�      " ��6    .�5�      ��  � �� �#E14D2A6;   �� 5�       � ��
 �����6;   �� 5�       � ��$ 20(�69   �� 5�       � ��$
 Bold"�6;   �� 5�       � ��$
 10,5q�68   �� 5�       � ��$ 0q�6@   �� 5�       � �� 5�   "   �� 5�   &   " ��66   .R�5�   *   �� #��z��61   #��z��5�   -   #��z��5�   -   $ 10��5�   -   ._�5�   .   �� $��Center=�6?   $��Center=�6�   5�   +   5�   '   5�      5�      .��5�   $   	아니요5�      5�      5�      5�      5�      