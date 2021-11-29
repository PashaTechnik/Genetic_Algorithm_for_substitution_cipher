//
//  XoRWithKey.swift
//  Security XoR
//
//  Created by Pasha on 29.11.2021.
//

import Foundation

class XoRWithKey {
    static func indexOfCoincidence(str1: String, str2: String) -> Float {
        let arr1 = Array(str1)
        let arr2 = Array(str2)
        var coincidence = 0
        for i in 0..<str1.count {
            if arr1[i] == arr2[i] {
                coincidence += 1
            }
        }
        return Float(coincidence)/Float(str1.count)
    }
    
    static func replace(_ str: String) -> String {
        let last = Array(str).last
        let newStr = String(last!) + str
        return String(newStr.dropLast())
    }
    
    static func textAnalyse(_ text: String){
        var dict: [Character : Int] = [:]
        for char in text {
            if !dict.keys.contains(char) {
                dict[char] = 1
            }
            else {
                dict[char] = dict[char]! + 1
            }
        }
        let sortedByValueDictionary = dict.sorted { $0.1 > $1.1 }
        for elem in sortedByValueDictionary {
            print("\(elem.key):\(elem.value)")
        }
    }
    
    static func getCoincidenceTable(_ text: String){
        for i in 0...50{
            print("\(i+1) positions:")
            let replaceTemp = replace(text)
            print(indexOfCoincidence(str1: text, str2: replaceTemp))
            print(" ")
        }

    }
    
    static func divideByKey(keyLength: Int, text: String) -> Array<String>{
        var arr: [String] = Array(repeating: "", count: keyLength)
        
        let arrayOfLetters = text.map(String.init)
        var index = 0
        for char in arrayOfLetters {
            arr[index % keyLength] += char
            index += 1
        }
        
        return arr
        
    }
    
    
    
}
