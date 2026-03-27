import "./App.css"
import { EmployeeList } from "./components/Employees/EmployeeList"
import { EmployeeDetails } from "./components/Employees/EmployeeDetails"
import { TicketList } from "./components/tickets/TicketList"
import { CustomerList } from "./components/customers/CustomersList"
import { CustomerDetails } from "./components/customers/CustomerDetails"
import { Routes, Route, Outlet } from "react-router-dom"
import { NavBar } from "./components/nav/NavBar"
import { Welcome } from "./components/welcome/Welcome"

export const App = () => {
  return (
    <Routes>
      <Route path="/"
        element={
          <>
            <NavBar/>
            <Outlet/>
          </>
        }
      >
        <Route index element={<Welcome/>} />
        <Route path="tickets" element={<TicketList/>} />
        <Route path="customers">
          <Route index element={<CustomerList/>}/>
          <Route path=":customerId" element={<CustomerDetails/>}/>
        </Route>
        <Route path="employees">
          <Route index element={<EmployeeList/>}/>
          <Route path=":employeeId" element={<EmployeeDetails/>}/>
        </Route>
      </Route>
    </Routes>
  )
}