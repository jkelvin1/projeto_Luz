   M S B A M L   `   `   `  ����N  JCRUD_ProdFinanceiro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CRUD_ProdFinanceiro.ViewModelCRUD_ProdFinanceiro.ViewModel  5   	   $    CRUD_ProdFinanceiro.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A	ViewModel+clr-namespace:CRUD_ProdFinanceiro.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��600��6)    � 
ResizeMode$ CanMinimize=�65   .��5	      � .+�5
   
   �� $	��200��6   $��10,10,0,300q�6    $
��Left=�65   .+�5      �� $��	Cadastrar��6   ��6)   �� * CreateProdutoFinanceiroCommand+�� 5      $��Buscar��6   ��6&   �� *ReadProdutoFinanceiroCommand+��6W   ��  �� ElementName$ 
lstProduto�� �� Path$ SelectedItem��� 5      $��Editar��6   ��6&   �� * UpdateProdutoFinanceiroCommand+��6Y   �� $ 
lstProduto��$ SelectedItem��� 5      $��Deletar��6   ��6'   �� * DeleteProdutoFinanceiroCommand+��6Z   �� $ 
lstProduto��$ SelectedItem�5      �� 5   
   $	��300��6   $��270,10,0,10q�6!   .+�5      �� -   5         ��Name$ 
lstProduto��5      ��6+   �� *ProdutoFinanceiro+ �� View 5      �� 5      .P�5      �� $��Sigla��6)    �� DisplayMemberBinding 68   �� *Sigla+�� 5      $
��Nome��6)    67   �� *Nome+�� 5      $��Setor��6)    68   �� *Setor+�� 5      $
��Tipo��6)    67   �� *Tipo+5      5      5      �� 5   
   $	��200��6   $��	10,50,0,0q�6   $
��Left=�62   .+�5      �� Sigla6   �� 5      $	��200��6   ��6"   �� *Sigla+�� 5      Nome6   �� 5       $	��200��6   ��6"   �� *Nome+�� 5!      Setor6   �� 5"      $	��200��6   ��6"   �� *Setor+�� 5#      Tipo6   �� 5$      $	��200��6    �� Text 6#   �� *Tipo+.@�5%      �� .��6   Ação6%   �� 5&      .��6   Fundo6&   5'      5(      5)      5+      