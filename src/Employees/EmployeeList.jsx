import "./Employees.css"
import { getAllEmployees } from "../services/employeeService"
import { useEffect, useState } from "react"
import { User } from "../users/User"

export const EmployeeList = () => {
  const [employees, setEmployees] = useState([])

  useEffect(() => {
    getAllEmployees().then((employeeArray) => {
      setEmployees(employeeArray)
    })
  }, [])

  return (
    <div className="employees">
      {employees.map((employeeObj) => {
        return <User key={employeeObj.id} user={employeeObj.user} />
      })}
    </div>
  )
}