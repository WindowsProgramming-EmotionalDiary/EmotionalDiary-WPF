   M S B A M L   `   `   `  ���� I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EmotionalDiary.ViewEmotionalDiary.View  '    !EmotionalDiary.View.CommunityPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:EmotionalDiary.View       N� Title$  CommunityPage��.��� ���#F7EEDD � RowDefinitions �� $��6* ���  � ColumnDefinitions �� $��3* ��� .+��� -    ��Name$ DetailPanel��$��0��$��0��$	��500��$	��800��$y�	Collapsed=�.+��� ���#FF9B50$	��600��$��80��$��Center=�$��Center=� �� CornerRadius$ 20, 20, 0, 0��._�� 
������ $��80��$	��600�� �� $
��2.5* ��� $��1* ��� $��1* �.+��� -    ��Name$ 
TitleLabel��$��30(�$
��Bold"�$
��Left=�$��Center=�$
��10,0q��� -   $ EmotionImage��$��1��$��Center=�$��Center=�$��50��$��60���� -   $ 	DateLabel��$��20(�$
��Bold"�$��2��$
��Left=�$��Center=��� -    ��Name$ ContentTextBlock��$��40(�
�������$	��433��$	��600��$
��Wrap=�� -    �Name$ 	heartGrid��$��1��$��0��$��Center=�$y�	Collapsed=�.+��� -   
������ 
������ .���� -   $ 
heartLabel��$	��♡��$��60(��� -	   $ CommunityStackPanel��$��0��$��1��$��Center=�$��10q�� $��1��$��1��.+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� ���#E14D2A$��80��$��80��$ 20��$��0, 0, 10, 0q�._��� -
   $��80��$��80��
������ 
������ .���� $��50(�.��◀�� ���#E14D2A$��80��$��80��$ 20��$��0, 0, 10, 0q�._��� -   $��80��$��80��
������ 
������ .���� $��50(�.��▶