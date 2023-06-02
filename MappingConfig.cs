using AutoMapper;
using System.Globalization;
using System.Text;
using VerstaTask.Models;
using VerstaTask.Models.Dtos;

namespace VerstaTask
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>()
                    .AfterMap((orderDto, order) =>
                    {
                        order.CargoWeight = decimal.Parse(orderDto.CargoWeightStr.Replace('.', ','));
                        var stringBuilder = new StringBuilder();
                        stringBuilder.Append(string.Join(", ", orderDto.SenderStreet, $"д. {orderDto.SenderHouseNumber}"));
                        if (orderDto.SenderCaseNumber is not null)
                        {
                            stringBuilder.Append(", ");
                            stringBuilder.Append($"к. {orderDto.SenderCaseNumber}");
                        }
                        if (orderDto.SenderFlatNumber is not null)
                        {
                            stringBuilder.Append(", ");
                            stringBuilder.Append($"кв. {orderDto.SenderFlatNumber}");
                        }
                        order.SenderAddress = stringBuilder.ToString();

                        stringBuilder.Clear();
                        stringBuilder.Append(string.Join(", ", orderDto.RecipientStreet, $"д. {orderDto.RecipientHouseNumber}"));
                        if (orderDto.RecipientCaseNumber is not null)
                        {
                            stringBuilder.Append(", ");
                            stringBuilder.Append($"к. {orderDto.RecipientCaseNumber}");
                        }
                        if (orderDto.RecipientFlatNumber is not null)
                        {
                            stringBuilder.Append(", ");
                            stringBuilder.Append($"кв. {orderDto.RecipientFlatNumber}");
                        }
                        order.RecipientAddress = stringBuilder.ToString();
                    });

                config.CreateMap<Order, OrderDto>()
                    .AfterMap((order, orderDto) =>
                    {
                        orderDto.CargoWeightStr = order.CargoWeight.ToString();

                        var parsedRecipientAddress = order.RecipientAddress.Split(", ");
                        orderDto.RecipientStreet = parsedRecipientAddress[0];
                        orderDto.RecipientHouseNumber = int.Parse(parsedRecipientAddress[1].Split(". ")[1]);
                        if (parsedRecipientAddress.Length > 2)
                        {
                            var thirdAddressPart = parsedRecipientAddress[2].Split(". ");
                            if (thirdAddressPart[0] == "к")
                            {
                                orderDto.RecipientCaseNumber = int.Parse(thirdAddressPart[1]);
                                orderDto.RecipientFlatNumber = parsedRecipientAddress.Length > 3 ?
                                    int.Parse(parsedRecipientAddress[3].Split(". ")[1]) : null;
                            }
                            else
                            {
                                orderDto.RecipientFlatNumber = int.Parse(thirdAddressPart[1]);
                            }
                        }

                        var parsedSenderAddress = order.SenderAddress.Split(", ");
                        orderDto.SenderStreet = parsedSenderAddress[0];
                        orderDto.SenderHouseNumber = int.Parse(parsedSenderAddress[1].Split(". ")[1]);
                        if (parsedSenderAddress.Length > 2)
                        {
                            var thirdAddressPart = parsedSenderAddress[2].Split(". ");
                            if (thirdAddressPart[0] == "к")
                            {
                                orderDto.SenderCaseNumber = int.Parse(thirdAddressPart[1]);
                                orderDto.SenderFlatNumber = parsedSenderAddress.Length > 3 ?
                                    int.Parse(parsedSenderAddress[3].Split(". ")[1]) : null;
                            }
                            else
                            {
                                orderDto.SenderFlatNumber = int.Parse(thirdAddressPart[1]);
                            }
                        }

                    });
            });
            return mappingConfig;
        }
    }
}
