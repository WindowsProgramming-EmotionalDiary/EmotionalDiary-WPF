   M S B A M L   `   `   `  ����I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EmotionalDiary.ViewEmotionalDiary.View  5   	       EmotionalDiary.View.Main   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:EmotionalDiary.View     5   	     � Title$
  Main��5   	   $	��800��6   $
��1080��6#    � 
ResizeMode$ NoResize=�60    � 	Resources 5	       �� 
TargetType   TabItemStyle �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value �� 
TargetName��%w  &	        �� 5
   
   " ��6   .�5      ��  � ��$	 350��6&   �� 5       � ��$ 60��6'   �� 5       � �� �#FAAD806+   �� 5       � ��$ 30(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �   �6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ Border��6%   $ 10��65   #��z��6G   $	 5q�6q   $��2q�6}   ._�5   "   �� $��Header��63   $��Center=�6J   $��Center=�6g   #��z��6�   5      5      
 5      P� 5       �@��
IsSelected$
 True��6<   . �5   "   �� $ Border��6)    � �� �#E14D2A6S   �� 5   "    � ��
 �����6?   5      P� 5       �@��
IsSelected$ False��6<   . �5   "   �� $ Border��6)    � �� �#FAAD806S   �� 5    "    � ��
 �   �6?   5!      5#      5%      5&      5'      .��5)      � ���#F7EEDD � RowDefinitions 5*   
   �� 5+      $
��Auto �6   �� 5,      $��* �6   .+�5.   
   �� -   5        $��Center=�5.      ���#F7EEDD$��0��6G   .@�5/      �� $��메인��6   #��[  6"   
 � Tag$ View/MainPage.xaml��6H   .��50      �� $��Center=�6   $��0q�65   $��10q�6I   
������ $��25(�6o   .��6}   &$당신과 함께하는 감정 일기6�   51      �� 52      $��	공동체��6   #��[  6#   $ View/CommunityPage.xaml��6I   .��53      �� $��Center=�6   $��0q�65   $��10q�6I   
������ $��25(�6o   .��6}   /-다른 사람의 이야기도 들어보아요6�   54      �� 55      $��다이어리��6   #��[  6$   $ View/DiaryPage.xaml��6J   .��56      �� $��Center=�6   $��0q�65   $��10q�6I   
������ $��25(�6o   .��6}   64오늘의 감정을 사진과 글로 남겨보세요6�   57      58       � 59   
   -   5          �Name$ 	MainFrame��59      $��1��6#     � NavigationUIVisibility$ Hidden=�60   5:      5;      