//
//  SimpleXoR.swift
//  Security XoR
//
//  Created by Pasha on 29.11.2021.
//

import Foundation

class SimpleXoR {
    
    func stringContain(str: String,template: String) -> Bool{
        for elem in template {
            if str.contains(elem) {
                return true
            }
        }
        return false
    }


    
    static func hexStringtoAscii(_ hexString : String) -> String {

        let pattern = "(0x)?([0-9a-f]{2})"
        let regex = try! NSRegularExpression(pattern: pattern, options: .caseInsensitive)
        let nsString = hexString as NSString
        let matches = regex.matches(in: hexString, options: [], range: NSMakeRange(0, nsString.length))
        let characters = matches.map {
            Character(UnicodeScalar(UInt32(nsString.substring(with: $0.range(at: 2)), radix: 16)!)!)
        }
        return String(characters)
    }
    
    static private func XoR(x: String, y: String) -> String {
        var xStr = Array(x)
        var yStr = Array(y)
        
        while yStr.count != xStr.count {
            if yStr.count > xStr.count {
                xStr = "0" + xStr
            }
            else {
                yStr = "0" + yStr
            }
        }
        
        var result = ""
        for i in 0..<xStr.count {
            if xStr[i] == yStr[i] {
                result += "0"
            }
            else {
                result += "1"
            }
        }
        return result
    }
    
    static func decrypt(_ text: String) -> String{
        let ascciiText = text
        
        var resArray: [String] = []
        for i in 0...256 {
            let text = ascciiText.asciiValues
            var res = ""
            
        
            for elem in text {
                let cipher = XoR(x: String(elem,radix: 2), y: String(i,radix: 2))
                let resChar = String(unicodeCodepoint: Int(cipher,radix: 2)!)
        
                res += resChar ?? "nil"
            }
            
            if res.contains(" ") {
                resArray.append(res)
            }
        }
        
        resArray.sort { (res1, res2) -> Bool in
            return res1.filter { " ".contains($0) }.count > res2.filter { " ".contains($0) }.count
        }
        
        print(resArray[0])
        return resArray[0]
        
    }
}
