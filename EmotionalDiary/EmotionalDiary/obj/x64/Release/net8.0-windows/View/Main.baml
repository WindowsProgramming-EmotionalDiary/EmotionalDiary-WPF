   M S B A M L   `   `   `  ���� I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EmotionalDiary.ViewEmotionalDiary.View      EmotionalDiary.View.Main   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:EmotionalDiary.View       � Title$
  Main��$	��800��$
��1080�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType   TabItemStyle �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Padding
 �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� " ��.���  � ��$	 350����  � ��$ 60����  � �� �#FAAD80��  � ��$ 30(���  � ��$
 Bold"���  � ��
 �   ���  � �� �� " ��.R�� .+��� $ Border��$ 10��#��z��$	 5q�$��2q�._��� $��Header��$��Center=�$��Center=�#��z��
 P�  �@��
IsSelected$
 True��. ��� $ Border�� � �� �#E14D2A��  � ��
 �����P�  �@��
IsSelected$ False��. ��� $ Border�� � �� �#FAAD80��  � ��
 �   �.��� ���#F7EEDD � RowDefinitions �� $
��Auto ��� $��* �.+��� -   $��Center=����#F7EEDD$��0��.@��� $��메인��#��[  
 � Tag$ View/MainPage.xaml��.���� $��Center=�$��0q�$��10q�
������ $��25(�.��&$당신과 함께하는 감정 일기�� $��	공동체��#��[  $ View/CommunityPage.xaml��.���� $��Center=�$��0q�$��10q�
������ $��25(�.��/-다른 사람의 이야기도 들어보아요�� $��다이어리��#��[  $ View/DiaryPage.xaml��.���� $��Center=�$��0q�$��10q�
������ $��25(�.��64오늘의 감정을 사진과 글로 남겨보세요 � -     �Name$ 	MainFrame��$��1��  � NavigationUIVisibility$ Hidden=�