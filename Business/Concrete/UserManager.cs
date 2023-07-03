using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.Constants;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), String.Format(Messages.USER_LISTED, id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.USERS_LISTED);
        }

        public IResult Add(User user)
        {
           _userDal.Add(user);
           return new SuccessResult(Messages.USER_ADDEED);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.USER_UPDATED);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.USERS_DELETED);
        }
    }
}