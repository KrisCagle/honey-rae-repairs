import "./Employees.css"
import { getAllEmployees } from "../../services/employeeService"
import { useEffect, useState } from "react"
import { User } from "../users/User"
import { Link } from "react-router-dom"

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
      return (
        <Link to={`/employees/${employeeObj.id}`} key={employeeObj.id}>
          <User user={employeeObj.user} />
        </Link>
      )
    })}
  </div>
)
}