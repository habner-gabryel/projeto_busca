# projeto_busca

O trabalho consiste em implementar um sistema de navega��o autom�tica de um agente
utilizando o algoritmo de busca em largura, profundidade, gulosa e A*. 

O agente deve ser capaz de calcular automaticamente a melhor rota para chegar a
qualquer ponto de um ambiente representado atrav�s de um grafo que conecta com seus
v�rtices as �reas, locais ou partes do caminho onde o agente pode navegar. O grafo
representa ent�o um cen�rio fict�cio que voc� deve criar, onde o agente ir� tentar encontrar
um pr�mio (estado objetivo) que se encontra em algum local diferente de onde o agente
inicia no ambiente (n� inicial), o grafo deve ter pelo menos 30 v�rtices. Al�m do pr�mio
final durante o percurso o agente tamb�m deve coletar recompensas que est�o espalhadas
no mapa. Os algoritmos de busca cega devem pegar as recompensas que aparecerem nos
v�rtices visitados durante a verifica��o do caminho que leva ao pr�mio final. J� os
algoritmos com heur�stica devem ter em sua heur�stica uma forma de avaliar se �
compensador deslocar da rota que leva para o pr�mio final para pegar recompensas que
estejam em v�rtices pr�ximos durante esse caminho.

O ambiente por onde o agente ir� navegar � formado por diversos tipos de terrenos e em
cada tipo de terreno o agente tem um grau de dificuldade diferente para andar. Por
exemplo, o agente consegue passar facilmente por um terreno solido e plano, porem ter�
dificuldade para andar em um terreno rochoso ou um p�ntano.
Os tipos de terrenos que comp�em o ambiente s�o:

Solido e plano � Custo: +1

Rochoso � Custo: +10

Arenosos� Custo: +4

P�ntano � Custo: +20

A melhor rota para chegar a um determinado ponto do ambiente � a rota que tem o menor
custo.

Requisitos do Trabalho:

� As figuras de exemplo mostram ideias para o mapa do ambiente que deve ser
desenvolvido. O s�mbolo �?� representa paredes (por onde o agente n�o pode passar
de nenhuma maneira), os espa�os em branco em diferentes cores representam os
locais onde o agente pode andar (cada cor representa um tipo de terreno), o s�mbolo
�?� representa o agente e as recompensas s�o representadas pelo s�mbolo �$�.
� permitido utilizar outros s�mbolos de sua prefer�ncia para representar os elementos.
A quantidade de recompensas no ambiente deve ser de no m�nimo 5.

� Ap�s calcular a melhor rota, o programa deve mostrar a movimenta��o do agente
seguindo a rota calcula.

� O Agente durante sua rota deve tentar pegar o m�ximo de recompensas poss�veis.

� O algoritmo deve ser capaz de perceber quando n�o existe nenhum caminho para
chegar ao destino ou se existem paredes, becos ou pontos sem sa�da. Exemplo: uma
sala que n�o possui nenhuma entrada ou uma parede que impede que o caminho
continue.

� Al�m de encontrar a melhor rota, fa�a um comparativo entre os resultados dos
algoritmos em rela��o a tempo de execu��o e quantidade de n�s expandidos na
mem�ria.

� A melhor maneira de come�ar o trabalho � pensando a fun��o heur�stica que ser�
utilizada pelos algoritmos Guloso e A*. Os algoritmos devem ser implementados de
forma correta e o c�digo organizado.