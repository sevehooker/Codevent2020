namespace Lib
open System.Text.RegularExpressions

module Day4 =
    
    let rec readPassport (data: string list) =
        match data with
        | head :: _ when head.Length = 0 -> ("", data)
        | head :: tail -> 
            let (passport, data) = readPassport(tail)
            (head + " " + passport, data)
        | [] -> ("", data)

    let rec parsePassports (data: string list) =
        match data with
        | head :: tail when tail.IsEmpty -> [head]
        | head :: tail when head.Length = 0 -> parsePassports(tail)
        | head :: tail -> 
            let (passport, nextPassport) = readPassport(head :: tail)
            passport.Trim() :: parsePassports(nextPassport)
        | [] -> []

    let checkFormat passport = Regex.IsMatch(passport, "(?=.*byr)(?=.*iyr)(?=.*eyr)(?=.*hgt)(?=.*hcl)(?=.*ecl)(?=.*pid).*$")
    
    let checkBirthYear passport = Regex.Match(passport, "byr:(.*?)(\s|$)").Groups.[1].Value |> int |> fun byr -> byr >= 1920 && byr <= 2002
    let checkIssueYear passport = Regex.Match(passport, "iyr:(.*?)(\s|$)").Groups.[1].Value |> int |> fun iyr -> iyr >= 2010 && iyr <= 2020
    let checkExpiration passport = Regex.Match(passport, "eyr:(.*?)(\s|$)").Groups.[1].Value |> int |> fun eyr -> eyr >= 2020 && eyr <= 2030
    let checkHeight passport = Regex.Match(passport, "hgt:(.*?)(\s|$)").Groups.[1].Value |> function
        | text when text.EndsWith("in") -> Regex.Match(text, "(\d+)in").Groups.[1].Value |> int |> fun hgt -> hgt >= 59 && hgt <= 76
        | text when text.EndsWith("cm") -> Regex.Match(text, "(\d+)cm").Groups.[1].Value |> int |> fun hgt -> hgt >= 150 && hgt <= 193
        | _ -> false
    
    let checkHairColor passport = Regex.Match(passport, "hcl:(.*?)(\s|$)").Groups.[1].Value
                               |> fun hcl -> hcl.Length = 7 && Regex.IsMatch(hcl, "[a-f0-9]{6}")
    let checkThoseEyes passport = Regex.Match(passport, "ecl:(.*?)(\s|$)").Groups.[1].Value |> function
        | "amb" | "blu" | "brn" | "gry" | "grn" | "hzl" | "oth" -> true
        | _ -> false
    let checkPassportID passport = Regex.Match(passport, "pid:(.*?)(\s|$)").Groups.[1].Value
                                |> fun pid -> pid.Length = 9 && Regex.IsMatch(pid, "\d{9}")

    let papersPlease passports =
        passports
        |> List.filter checkFormat
        |> List.filter checkBirthYear
        |> List.filter checkIssueYear
        |> List.filter checkExpiration
        |> List.filter checkHeight
        |> List.filter checkHairColor
        |> List.filter checkThoseEyes
        |> List.filter checkPassportID
        |> List.length