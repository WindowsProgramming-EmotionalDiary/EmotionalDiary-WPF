   M S B A M L   `   `   `  ����I  EEmotionalDiary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:EmotionalDiary.ViewEmotionalDiary.View  5      #    EmotionalDiary.View.DiaryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:EmotionalDiary.View     5        N� Title$  	DiaryPage��5	      .��5      � ���#F7EEDD � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $	��620��6"   $��Center=�6.   $��	0,50,0,50q�6K   .+�5      �� ���#FF9B50$	��620��6*   $��50��66   $��Center=�6B   $��Center=�6_    �� CornerRadius$ 20, 20, 0, 0��6z   ._�5      �� -   5        $��TitleTextBox��5      $��40(�6.   $
��Bold"�6<   $��제목을 입력하세요��6N   
������ $��0q�6x   $��Center=�6�   $
��10,0q�6�   5      �� 5      -   5        $��ContentTextBox��5   $   $��30(�6   
�������$	��358��6M   $��내용을 입력하세요��6Z    �� TextWrapping$
 Wrap=�6k    �� AcceptsReturn$
 True��6    J� RenderTransformOrigin$ 0.5,0.5&�6�   .��6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.263Q�6(   �� 5      T� 5       T� X$
 0.69Q�6-   5       .��5!   +   5"      5#      � 5%   
   $��1��6   $��2��6   .+�5&      �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5'      �� -   5        
 ��Name$
 	check_btn��5'      ���#E14D2A$	��200��6A   $��78��6M   $ 20��6Y   $��30q�6k   $y�	Collapsed=�6w   ._�5(      �� -   5        $��80��5(      $	��150��6)   ���#E14D2A
������ .��5)      �� $��25(�6    $
��Bold"�6.   .��6@   확인6D   5*      5+      �� 5,      ���#E14D2A$	��200��6.   $��78��6:   $ 20��6F   $��30q�6X   ._�5-      �� -   5        $��80��5-      $	��150��6)   ���#E14D2A
������ .��5.      �� $��25(�6    $
��Bold"�6.   .��6@   촬영6D   5/      50      51      52      �� 54   
   $��0��6   $��1��6"   $��0, 50, 20, 0q�62   $	��400��6H   .+�55      �� ���#FF9B50$	��400��6*   $��50��66   $��Center=�6B   $��Center=�6_   $ 20, 20, 0, 0��6z   ._�56      �� $��30(�6   $��Center=�6*   $��Center=�6G   $
��Bold"�6b   달력6x   57      &   System.Windows.Controls.Calendar  58      -   5          Name$ DiaryCalendar��58      $	��173��6.    � LayoutTransform 59      �� 5:       �� ScaleX$	 2.4Q�6%    �� ScaleY$	 2.2Q�62   5<      5=      5>      5?      