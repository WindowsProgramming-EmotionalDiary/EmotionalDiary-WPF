   M S B A M L   `   `   `  ���� I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EmotionalDiary.ViewEmotionalDiary.View  "    EmotionalDiary.View.MainPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:EmotionalDiary.View       N� Title$  MainPage�� � 	Resources &   System.Windows.Controls.Calendar �� 
TargetType �� Property �� Value5  /System.Windows.Controls.Primitives.CalendarItem:  4System.Windows.Controls.Primitives.CalendarDayButton �� Triggers P� Property P� Value7  1System.Windows.Controls.Primitives.CalendarButton��%�  '        '  �     '  i    '  �    �� "  .���  � �� �#333333��  � ��$ 12(���  � ��$ Segoe UI)���  � ��
 �������  � ��$ Center=���  � ��$ Center=���  �@ IsTodayHighlighted$
 True����  �@ SelectionMode$ 
SingleDate=��� "  .���  � ��
 �������  � �� �#CCCCCC��  � ��$ 1q���  � ��$ 0q��� "  .���  � ��$ 12(���  � ��$
 Bold"���  � �� �#333333��  � ��
 ���� ��  � ��
 ���� ��  � ��$ 0q���  � ��$ 0q� P�  �@J�IsMouseOver$
 True��. ���  � �� �#EEEEEEP�  �@ 
IsSelected$
 True��. ���  � �� �#FFCC00��  � ��
 ������� "  .���  � ��$ 10(���  � ��$
 Bold"���  � �� �#666666��  � ��
 ���� ��  � ��
 ���� ��  � ��$ 0q� P�  �@J�IsMouseOver$
 True��. ���  � �� �#FFCC00.���� ���#F7EEDD.+���  �� Orientation$ 
Horizontal=�.+��� $	��340��$	��740��$��0, 30, 0 , 0q�.+��� ���#FF9B50$	��270��$��50��$��Center=�$��Center=�	 �� CornerRadius$	 20, 20, 0, 0��._��� $
��Bold"�$��30(�$��Center=�$��Center=�오늘 할 일�� 
�������$	��270��$	��254��$	 0, 0, 20, 20��._��� .+��� $ 
Horizontal=�$��50��.+��� -   
 ��Name$
 check1��$��20��$��20��$��10, 5 , 0, 0q� � LayoutTransform ��  �� ScaleX$	 1.5Q� �� ScaleY$	 1.5Q��� -    ��Name$ todo1��$	��220��$��30��$��18(�$��Center=��� $ 
Horizontal=�$��50��.+��� -   $
 check2��$��20��$��20��$��10, 5 , 0, 0q� �� $	 1.5Q�$	 1.5Q��� -   $ todo2��$	��220��$��30��$��18(�$��Center=��� $ 
Horizontal=�$��50��.+��� -   $
 check3��$��20��$��20��$��10, 5 , 0, 0q� �� $	 1.5Q�$	 1.5Q��� -   $ todo3��$	��220��$��30��$��18(�$��Center=��� $ 
Horizontal=�$��50��.+��� -   $
 check4��$��20��$��20��$��10, 5 , 0, 0q� �� $	 1.5Q�$	 1.5Q��� -   $ todo4��$	��220��$��30��$��18(�$��Center=��� $ 
Horizontal=�$��50��.+��� -	   $
 check5��$��20��$��20��$��10, 5 , 0, 0q� �� $	 1.5Q�$	 1.5Q��� -
   $ todo5��$	��220��$��30��$��18(�$��Center=��� $��5, 30, 5, 0q�.+��� ���#FF9B50$	��270��$��50��$��Center=�$��Center=�$	 20, 20, 0, 0��$��0, 10 , 0, 0q�._��� $��30(�$
��Bold"�$��Center=�$��Center=�
내 정보�� 
�������$	��270��$	��195��$	 0, 0, 20, 20��._��� .+��� $ 
Horizontal=� J� RenderTransformOrigin$ 0.5,0.5&�$��45��$��2q�z�V� .~��� ��  �� AngleX$
 0.57Q��� T�  T� X$ 0.323Q�.+��� $ 
Horizontal=�$��45��$��2q�.+��� $��22(�$��
0, 5, 0, 0q�
이름 :�� -    ��Name$ myName��$��22(�$��20, 5, 0, 0q��� $ 
Horizontal=�$��45��$��2q�.+��� $��22(�$��
0, 5, 0, 0q�생년월일 :�� -   $ myAge��$��22(�$��20, 5, 0, 0q��� $ 
Horizontal=�$��45��$��2q�.+��� $��22(�$��
0, 5, 0, 0q�전화번호 :�� -   $ myTel��$��22(�$��20, 5, 0, 0q��� $ 
Horizontal=�$��45��$��2q�.+��� $��22(�$��
0, 5, 0, 0q�
주소 :�� -   $ 	myAddress��$��17(�$��20, 8, 0, 0q��� $��
0, 0, 0, 0q�$	��400��.+��� -   $ ToDayEmotion��$��30, 40, 0, 0q�$��40(�오늘 감정 :�� ���#FF9B50$	��357��$��50��$��Center=�$��Center=�$	 20, 20, 0, 0��$��0, 40, 0, 0q�._��� $��30(�$��Center=�$��Center=�$
��Bold"�달력  $	��173��$��0, -6, 0 ,0q� �� $ 2Q�$ 2Q��� $	��314��.+��� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�😲 놀람�� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�😠 분노�� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�😨 불안�� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�🙁 상처�� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�😪 슬픔�� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�😐 중립�� $��Segoe UI Emoji)�$��30(�$��Center=�$��Center=�$��10, 15q�😁 행복�� $ 
Horizontal=�$��-100, 30, 0, 0q�.+��� -   ���#E14D2A$	��180��$��78��$	 20��$��0, 0, 30, 0q�._��� $��Center=�$��Center=�$��25(�치매예방게임�� ���#E14D2A$	��180��$��78��$	 20��._��� -   $��Center=�$��Center=�$��30(�종료