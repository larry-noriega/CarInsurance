﻿using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarPolicy;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CarInsurance.Infrastructure.Data;

public class CarPoliciesRepository : ICarPoliciesRepository
{
    private readonly ICarPoliciesContext _context;

    public CarPoliciesRepository(ICarPoliciesContext context)
    {
        _context = context;
    }

    public async Task<List<Policy>> GetAsync() =>
        await _context.CarPolicies.Find(_ => true).ToListAsync();

    public async Task<Policy?> GetAsync(Expression<Func<Policy, bool>> filter) =>
       await _context.CarPolicies.Find(filter).FirstOrDefaultAsync();


    public async Task CreateAsync(Policy carPolicy) =>
        await _context.CarPolicies.InsertOneAsync(carPolicy);

    public async Task UpdateAsync(string id, Policy updatedCarPolicy) =>
        await _context.CarPolicies.ReplaceOneAsync(doc => doc.Id == id, updatedCarPolicy);

    public async Task RemoveAsync(string id) =>
        await _context.CarPolicies.DeleteOneAsync(doc => doc.Id == id);    
}
