# Exemplo que gera estatísticas para a solução do problema proposto no vídeo https://www.youtube.com/watch?v=iSNsgj1OCLA&t=7s

O vídeo explica uma solução para o seguinte problema:

Existem 100 prisioneiros numerados de 1 a 100.
100 papéis contendo cada um o número de um prisioneiro são colocados de forma aleatória dentro de caixas, com cada caixa contendo apenas 1 papel.
Os prisioneiros entram 1 a 1 na sala e podem abrir quaisquer 50 caixas em busca do seu número.
Depois disso, o prisioneiro deve deixar a sala exatamente da forma como estava quando entrou.
Ele não pode se comunicar de nenhuma forma com os outros prisioneiros.
Se todos os 100 prisioneiros conseguirem achar seu número, todos serão libertados.
Nas se 1 dos prisioneiros não encontrar o número, todos são executados.
Os prisioneiros podem criar uma estratégia antes que o primeiro entre na sala.

Qual é a melhor estratégia que eles podem seguir?


`ExecutarRodadaPrisioneiroAleatorio()` simula o caso em que cada prisioneiro abre 50 caixas aleatórias.
`ExecutarRodadaLoop()` simula a solução proposta no vídeo.