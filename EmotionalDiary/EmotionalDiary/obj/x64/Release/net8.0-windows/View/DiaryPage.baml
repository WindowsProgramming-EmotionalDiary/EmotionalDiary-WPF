   M S B A M L   `   `   `  ���� I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EmotionalDiary.ViewEmotionalDiary.View  #    EmotionalDiary.View.DiaryPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:EmotionalDiary.View       N� Title$  	DiaryPage��.��� ���#F7EEDD � RowDefinitions �� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$	��620��$��Center=�$��	0,50,0,50q�.+��� ���#FF9B50$	��620��$��50��$��Center=�$��Center=� �� CornerRadius$ 20, 20, 0, 0��._��� .+��� -    ��Name$ clearBtn��$��제목을 입력하세요��
������ 
������ $��0, 0, 0, -50q�$��30(�$
��Bold"� K� ZIndex$ 2���� -   $��TitleTextBox��$��40(�$
��Bold"�$�� ��
������ $��0q�$��Center=�$
��10,0q��� -   $ 	clearBtn1��$��내용을 입력하세요��
������ 
������ $��0, 0, 0, -350q�$��30(�$
��Bold"�$ 2��$	��336���� -   $��ContentTextBox��$��30(�
�������$	��358��$�� �� �� TextWrapping$
 Wrap=� �� AcceptsReturn$
 True�� J� RenderTransformOrigin$ 0.5,0.5&�.��z�V� .~��� �� 	 �� AngleX$	 0.263Q��� T� 
 T� X$

 0.69Q�.��� $��1��$��2��.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -    ��Name$ 	check_btn�����#E14D2A$	��200��$��78��$ 20��$��30q�$y�	Collapsed=�._��� -   $��80��$	��150�����#E14D2A
������ .���� $��25(�$
��Bold"�.��확인�� ���#E14D2A$	��200��$��78��$ 20��$��30q�._��� -   $��80��$	��150�����#E14D2A
������ .���� $��25(�$
��Bold"�.��촬영�� $��0��$��1��$��0, 50, 20, 0q�$	��400��.+��� ���#FF9B50$	��400��$��50��$��Center=�$��Center=�$ 20, 20, 0, 0��._��� $��30(�$��Center=�$��Center=�$
��Bold"�달력&   System.Windows.Controls.Calendar  -     Name$ DiaryCalendar��$	��173�� � LayoutTransform ��  �� ScaleX$	 2.4Q� �� ScaleY$	 2.2Q�