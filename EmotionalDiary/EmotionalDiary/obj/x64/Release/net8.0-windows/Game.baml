   M S B A M L   `   `   `  ���� I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EmotionalDiaryEmotionalDiary      EmotionalDiary.Game   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:EmotionalDiary       � Title$  
MainWindow��$	��800��$	��800�� � 	Resources    TextBoxStyle �� 
TargetType �� Property �� Value  TextBlockStyle��%o  &	        &	 �     �� " ��.���  � ��$ 80(���  � ��$	 110����  � ��$	 110����  � ��$ 23q���  � �� �#FFFFFF��  � �� �#E14D2A��  � ��$ 0q���  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��$ 50(���  � �� �#000000��  � ��$ Center=���  � ��$ Center=�.��� .+�� -    �Name$ 
gameScreen��$y�Visible=����#F7EEDD � RowDefinitions �� $��4* ��� $��1* �.+�� -   $ mainGrid�� � ShowGridLines$
 True�� � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* � �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� -   $�� ��$	��120(�$��Center=�$��Center=�$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��1��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��2��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��3��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��1��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��1��$��1��$
��Wrap=��� -	   $�� ��$	��120(�$��Center=�$��Center=�$��1��$��2��$
��Wrap=��� -
   $�� ��$	��120(�$��Center=�$��Center=�$��1��$��3��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��2��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��2��$��1��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��2��$��2��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��2��$��3��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��3��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��3��$��1��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��3��$��2��$
��Wrap=��� -   $�� ��$	��120(�$��Center=�$��Center=�$��3��$��3��$
��Wrap=�� $��1�� �� $��1* �.+��� -   	 ��Name$	 TimeTextBlock��$��Center=�$
��Wrap=�$�� ��$��Center=�$��4��$��50(��� -   
 ��Name$
 answerScreen��$y�Hidden=����#F7EEDD.+��� #��[ 앞에서 눌린 숫자들을�� #��[ " 순서대로 입력해주세요!��  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ TextBox1��#��[  �� -   $ TextBox2��#��[  �� -   $ TextBox3��#��[  �� -   $ TextBox4��#��[  �� -   $ TextBox5��#��[  �� -   $	 printe��$��50(��� -   $
 output��.+��� -   $	 average_response��#��[ $��
45 20 45 0q��� -   $	 
answer_num��#��[ $��
45 20 45 0q��� -   $
 reaction_age��$��Center=�$��Center=�$y�Hidden=�$ 
Horizontal=�.+��� #��[ $��
45 20 25 0q�반응속도 나이 :�� -   $	 responseAge��#��[ $��0 20 0 0q��� -    $
 
memory_age��$��Center=�$��Center=�$y�Hidden=�$ 
Horizontal=�.+��� #��[ $��
45 20 25 0q�기억력 나이 :�� -!   $	 	memoryAge��#��[ $��0 20 0 0q��� -"   $
	 test���� $ 
Horizontal=�.+��� -#   $	 	try_again��#��[ $y�Hidden=��� -$    ��Name$ ok��$y�Hidden=�$��80��$��80��$��80, 0, 20, 0q����� " ��.���  � �� �#E14D2A��  � ��
 �������  � ��$ 20(���  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 0q���  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 10��._��� $��Center=�$��Center=�.��네�� -%   $ no��$y�Hidden=�$��80��$��80��$��20, 0, 20, 0q����� " ��.���  � �� �#E14D2A��  � ��
 �������  � ��$ 20(���  � ��$
 Bold"���  � ��$
 10,5q���  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��#��z��$ 10��._��� $��Center=�$��Center=�.��	아니요