using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger) {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber) {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber) {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber) {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber) {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber) {
            if (isNumeric(firstNumber) && isNumeric(secondNumber)) {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Raiz(string firstNumber) {
            if (isNumeric(firstNumber)) {
                var raiz = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(raiz.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber) {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }

        private bool isNumeric(string strNumber) {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
        }
    }
}
