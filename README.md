# AutoTimeTable-Generator
 To Run This Project you Need To install SAP Crystal Reports on your system [Click Here](https://www.tektutorialshub.com/crystal-reports/download-crystal-reports-for-visual-studio-2019/) :point_left:to install it.<br/>
```Note: The Password Of zip File Is my Github Username```

This repository contains the project and code related to the **Timetable Scheduling** project, which was part of the Data Structures and Algorithms course at Bahria University, Karachi Campus.

## Project Overview

### Introduction & Problem
#### Existing System
Today, to conduct an exam various faculty related to each subject will make the timetable whereas for the examination like IIT, SSC the administration makes a group who will decide the timetable, and then they make arrangement for the exam. In this type of process, it consumes large time and is not focused on the student’s problem. If the exam had to postpone then it is a huge problem as they need to re-arrange all the things. While a student has to make a timetable for the exam itself and if the daily routine is not good the student will not able use their full potential.
#### Proposed System
The Exam Scheduler System will be automated and will help the institution to arrange the exam in the most efficient and optimized way. The system will make the timetable such that it will focus on the student’s problem of back-to-back exam, exam overloading so the students will not face any of these problems and can make use of their full potential. The Exam Scheduler System will assign the invigilators based on the knowledge they have. The software will support multiple exams at a time while the reports can be taken out of the system in various standard files.

### Paradigms
The paradigm used in timetable scheduling system is OBJECT ORIENTED PROGRAMMING (OOP).
The main necessity behind inventing object oriented approach is to remove the drawback encountered in the procedural approach. The programming paradigm object treats data as an element in the program development and holds it tightly rather than allowing it to move freely around the system. It ties the data to the function that operates on it and hides and protects it from accidental updates by external functions. Object oriented programming paradigm allows decomposition of the system into the number of entities called objects and then ties properties and function to these objects. An object’s properties can be accessed only by the functions associated with that object but functions of one object can access the function of other objects in the same cases using access specifiers.

UML class diagram to explain how OOP is used in timetable scheduling system:
<div align="center">
  <img src="https://github.com/user-attachments/assets/bcb4c933-128e-4b72-aea0-f4e80b6deefb" alt="Image Description">
</div>

### Algorithm & Explanation
A genetic algorithm is a search heuristic that is inspired by Charles Darwin’s theory of natural evolution. This algorithm reflects the process of natural selection where the fittest individuals are selected for reproduction in order to produce offspring of the next generation.
<div align="center">
  <img src="https://github.com/user-attachments/assets/fa0a7fc9-c452-4443-b024-3a94e16312a8" alt="Image Description">
</div>

#### Notion of Natural Selection
The process of natural selection starts with the selection of fittest individuals from a population. They produce offspring which inherit the characteristics of the parents and will be added to the next generation. If parents have better fitness, their offspring will be better than parents and have a better chance at surviving. This process keeps on iterating and at the end, a generation with the fittest individuals will be found.
This notion can be applied for a search problem. We consider a set of solutions for a problem and select the set of best ones out of them.
Five phases are considered in a genetic algorithm.
1.	Initial population
2.	Fitness function
3.	Selection
4.	Crossover
5.	Mutation

•	**Initial Population**
The process begins with a set of individuals which is called a Population. Each individual is a solution to the problem you want to solve. An individual is characterized by a set of parameters (variables) known as Genes. Genes are joined into a string to form a Chromosome (solution). In a genetic algorithm, the set of genes of an individual is represented using a string, in terms of an alphabet. Usually, binary values are used (string of 1s and 0s). We say that we encode the genes in a chromosome.
<div align="center">
  <img src="https://github.com/user-attachments/assets/05e29163-50b4-4e7a-a1e4-0e2d07932a5e" alt="Encoded Genes in a Chromosome">
</div>

 •	**Fitness Function**
The fitness function determines how fit an individual is (the ability of an individual to compete with other individuals). It gives a fitness score to each individual. The probability that an individual will be selected for reproduction is based on its fitness score.

•	**Selection**
The idea of selection phase is to select the fittest individuals and let them pass their genes to the next generation. Two pairs of individuals (parents) are selected based on their fitness scores. Individuals with high fitness have more chance to be selected for reproduction.

• **Crossover**  
Crossover is the most significant phase in a genetic algorithm. For each pair of parents to be mated, a crossover point is chosen at random from within the genes.  
For example, consider the crossover point to be 3 as shown below.

<div align="center">
  <img src="https://github.com/user-attachments/assets/e28d7d28-ce1b-453e-887e-4c95b04d1138" alt="Crossover Example">
</div>

Offspring are created by exchanging the genes of parents among themselves until the crossover point is reached.
<div align="center">
  <img src="https://github.com/user-attachments/assets/1b9aad2f-ae16-4a89-92ec-6b2bf6ddefa2" alt="Gene Exchange at Crossover Point">
</div>
The new offspring are added to the population.
<div align="center">
  <img src="https://github.com/user-attachments/assets/34a449b9-2d4c-4576-9b33-fed5cfa68aa2" alt="New Offspring Added to Population">
</div>

•	**Mutation**
In certain new offspring formed, some of their genes can be subjected to a mutation with a low random probability. This implies that some of the bits in the bit string can be flipped.

<div align="center">
  <img src="https://github.com/user-attachments/assets/1cf32ab2-1907-4043-aa73-9ee8cde16bfc" alt="Gene Mutation Example">
</div>

Mutation occurs to maintain diversity within the population and prevent premature convergence.

Termination
The algorithm terminates if the population has converged (does not produce offspring which are significantly different from the previous generation). Then it is said that the genetic algorithm has provided a set of solutions to our problem.


Comments
The population has a fixed size. As new generations are formed, individuals with least fitness die, providing space for new offspring.
The sequence of phases is repeated to produce individuals in each new generation which are better than the previous generation.


### Conclusion
The objectives of this project are, first, to introduce Genetic Algorithm and, secondly, to use it to solve a timetable scheduling problem. The objectives are to define what Genetic Algorithms are and how its work, to define what is timetable management and its actual problems and to make a prototype of an automated timetable scheduling system without using the classical approach but the Genetic Algorithm.

### Project Distribution
- **Mutayyab Imran**: Implementation of the Genetic Algorithm.
- **Sara Najam Khan**: Development of session and user authentication forms.
- **Barirah Bakhtiar**: Creation of course and timetable forms.

Feel free to explore the project and reach out if you have any questions or feedback.

