using LobbyApi.Data;
using LobbyApi.DTOs;
using LobbyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly LobbyContext _context;

        public FriendRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FriendDTO>> GetFriend(string id)
        {
            return await _context.Friends
                .Where(f => f.UserId == id)
                .Include(f => f.User2)
                .Select(f => new FriendDTO()
                {
                    UserId = f.UserId2,
                    UserName = f.User2.UserName
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<FriendPostDTO> PostFriend(FriendPostDTO friendPostDTO)
        {
            if (friendPostDTO == null) { throw new ArgumentNullException(nameof(friendPostDTO)); }

            _context.Friends.Add(new Friend()
            {
                UserId = friendPostDTO.UserId,
                UserId2 = friendPostDTO.UserId2
            });

            _context.Friends.Add(new Friend()
            {
                UserId = friendPostDTO.UserId2,
                UserId2 = friendPostDTO.UserId
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return friendPostDTO;
        }

        public async Task<FriendDeleteDTO> DeleteFriend(FriendDeleteDTO friendDeleteDTO)
        {
            var friend = await _context.Friends
                .Where(f => f.UserId == friendDeleteDTO.UserId && f.UserId2 == friendDeleteDTO.UserId2)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var friend2 = await _context.Friends
                .Where(f => f.UserId == friendDeleteDTO.UserId2 && f.UserId2 == friendDeleteDTO.UserId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (friend == null)
            {
                return null;
            }

            _context.Friends.Remove(friend);
            _context.Friends.Remove(friend2);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return friendDeleteDTO;
        }
    }
}
