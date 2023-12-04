# Campo Minado
Objetivo: revelar um campo de minas sem que alguma seja detonada.

A área de jogo consiste num campo de quadrados retangular. Cada quadrado pode ser revelado com uma ação do jogador, e se o quadrado revelado contiver uma mina, o jogo acaba. Se, por outro lado, o quadrado não contiver uma mina, uma de duas coisas poderá acontecer:

Um número aparece, indicando a quantidade de quadrados adjacentes que contêm minas;
Nenhum número aparece, e o jogo revela automaticamente os quadrados que se encontram adjacentes ao quadrado vazio, já que não podem conter minas.
O jogo é ganho quando todos os quadrados que não têm minas são revelados.

O jogador pode, com uma ação, sinalizar ou retirar uma sinalização de qualquer quadrado que acredita que contém uma mina. Um quadrado sinalizado não pode ser aberto.

Busque vídeos e alguma implementação online para entender melhor o jogo.

[🗃 Arquivo `.zip` com a versão portável](dist/Campo-Minado.zip)

Para executar:

* `dotnet Campo-Minado.dll`