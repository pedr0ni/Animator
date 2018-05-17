# C# Animator

Easy animations in C#

## Introdução

Projeto teste para animações de Controls (System.Windows.Forms)

### Instalação

Você precisa apenas da classe Animator.cs

## Exemplos

### Scroll

```c#
Animator anim = new Animator(this.btn_animate);
anim.setAnimationType(AnimationType.SCROLL);
anim.setVelocity(1000);
anim.setMaxVector(597, 12);
anim.start();
```

### Size In/Out

```c#
Animator anim = new Animator(this.btn_animate);
anim.setAnimationType(AnimationType.SIZE_IN); // Or SIZE_OUT
anim.setVelocity(1000);
anim.start();
```

* A velocidade ~ Animator.setVelocity(int v) ~ é um número inteiro de quantidade de vezes que o evento será executado por segundo.

## Créditos

* General-Doomer (FrequencyRunner.cs)

## Autor

* Matheus Pedroni

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
