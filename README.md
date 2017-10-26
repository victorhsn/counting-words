# Counting Words

This project was build with .Net Framework 4.6.1. It is a Web API application that receive the follow JSON:

```
{
  "Sentence": "Lorem ipsum dolor sit amet, consecteur adipiscing elit",
  "Lengths": [3,4,5,26]
}
```

And return the follow JSON:

```
{
    "Results": [
        {
            "Length": 3,
            "Count": 1,
            "Words": ["sit"]
        },
        {
            "Length": 4,
            "Count": 2,
            "Words": ["amet","elit"]
        },
        {
            "Length": 5,
            "Count": 3,
            "Words": ["lorem","ipsum","dolor"]
        },
        {
            "Length": 26,
            "Count": 0,
            "Words": [""]
        }
    ]
}
```

## Envirenoment
Windows 10
Visual Studio 2015


